using KBYAIALPR;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace LicensePlateRecognition_C_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            textBoxMachineCode.Text = AlprSDK.GetMachineCode();

            try
            {
                string license = File.ReadAllText("license.txt");
                int ret = AlprSDK.SetActivation(license);
                if (ret == (int)SDK_ERROR.SDK_SUCCESS)
                {
                    ret = AlprSDK.InitSDK("model");
                    if (ret == (int)SDK_ERROR.SDK_SUCCESS)
                    {
                        MessageBox.Show("Init Successful!");
                    }
                    else
                    {
                        MessageBox.Show("Init Failed!");
                    }
                }
                else
                {
                    throw new Exception("Activtaion Failure!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Activtaion Failure!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                String fileName = openFileDialog1.FileName;

                Image image = null;
                try
                {
                    image = LoadImageWithExif(fileName);
                }
                catch (Exception)
                {
                    MessageBox.Show("Unknown Format!");
                    return;
                }

                Bitmap imgBmp = ConvertTo24bpp(image);
                BitmapData bitmapData = imgBmp.LockBits(new Rectangle(0, 0, imgBmp.Width, imgBmp.Height), ImageLockMode.ReadWrite, imgBmp.PixelFormat);

                int bytesPerPixel = Bitmap.GetPixelFormatSize(imgBmp.PixelFormat) / 8;
                int stride = bitmapData.Stride;

                // Allocate array with width * 3 for each pixel's RGB values
                byte[] pixels = new byte[imgBmp.Width * 3 * imgBmp.Height];

                IntPtr ptrFirstPixel = bitmapData.Scan0;
                byte[] rawData = new byte[stride * imgBmp.Height];
                Marshal.Copy(ptrFirstPixel, rawData, 0, rawData.Length);

                // Copy only the RGB data, ignoring any padding
                for (int y = 0; y < imgBmp.Height; y++)
                {
                    int rawOffset = y * stride;
                    int pixelOffset = y * imgBmp.Width * 3;

                    Marshal.Copy(rawData, rawOffset, Marshal.UnsafeAddrOfPinnedArrayElement(pixels, pixelOffset), imgBmp.Width * 3);
                }

                imgBmp.UnlockBits(bitmapData);


                ALPR_RESULT[] alprResults = new ALPR_RESULT[20];
                int resultCount= AlprSDK.Detection(pixels, imgBmp.Width, imgBmp.Height, alprResults, 20);
                if (resultCount > 0)
                {
                    using (Graphics graphics = Graphics.FromImage(image))
                    {
                        for(int i = 0; i < resultCount; i ++)
                        {
                            int width = alprResults[i].lp_x2 - alprResults[i].lp_x1;
                            int height = alprResults[i].lp_y2 - alprResults[i].lp_y1;

                            using (Pen pen = new Pen(Color.Yellow, 10)) // Red color with 3px thickness
                            {
                                graphics.DrawRectangle(pen, alprResults[i].lp_x1, alprResults[i].lp_y1, width, height);
                            }


                            width = alprResults[i].vl_x2 - alprResults[i].vl_x1;
                            height = alprResults[i].vl_y2 - alprResults[i].vl_y1;

                            using (Pen pen = new Pen(Color.Green, 10)) // Red color with 3px thickness
                            {
                                graphics.DrawRectangle(pen, alprResults[i].vl_x1, alprResults[i].vl_y1, width, height);
                            }

                            using (Font font = new Font("Arial", 50, FontStyle.Bold))
                            using (SolidBrush brush = new SolidBrush(Color.Yellow))
                            {
                                graphics.DrawString(alprResults[i].number + " " + alprResults[i].score.ToString("F3"), font, brush, alprResults[i].vl_x1, alprResults[i].vl_y1 - 25);
                            }
                        }
                    }
                }
                else
                {
                }

                pictureBox1.Image = image;
            }
        }

        public static Bitmap ConvertTo24bpp(Image img)
        {
            var bmp = new Bitmap(img.Width, img.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            using (var gr = Graphics.FromImage(bmp))
                gr.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height));
            return bmp;
        }


        public static Bitmap CropImage(Image img, Rectangle cropArea)
        {
            Bitmap bmpImage = new Bitmap(img);
            return bmpImage.Clone(cropArea, bmpImage.PixelFormat);
        }

        public static Image LoadImageWithExif(String filePath)
        {
            try
            {
                Image image = Image.FromFile(filePath);

                // Check if the image has EXIF orientation data
                if (image.PropertyIdList.Contains(0x0112))
                {
                    int orientation = image.GetPropertyItem(0x0112).Value[0];

                    switch (orientation)
                    {
                        case 1:
                            // Normal
                            break;
                        case 3:
                            // Rotate 180
                            image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                            break;
                        case 6:
                            // Rotate 90
                            image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                            break;
                        case 8:
                            // Rotate 270
                            image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                            break;
                        default:
                            // Do nothing
                            break;
                    }
                }

                return image;
            }
            catch (Exception e)
            {
                throw new Exception("Image null!");
            }
        }

        public byte[] BitmapToJpegByteArray(Bitmap bitmap)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                // Save the Bitmap as JPEG to the MemoryStream
                bitmap.Save(memoryStream, ImageFormat.Jpeg);
                // Return the byte array
                return memoryStream.ToArray();
            }
        }

        public static Bitmap ConvertJpgByteArrayToBitmap(byte[] jpgData)
        {
            using (MemoryStream ms = new MemoryStream(jpgData))
            {
                return new Bitmap(ms);
            }
        }

    }
}
