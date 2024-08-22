using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;


namespace PhotoViewer
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

            try 
            { 
                pbDisplay.Image = Image.FromFile(FileHelper.DeserializeFromFile()); 
            }
            catch { }

            EnableOrDisableStopViewingImageButton();
            AllowDroppingImagesOrFolderToPictureBox();
            if(IsMaximized)
                WindowState = FormWindowState.Maximized;

        }

        string[] _imagePaths;
        ushort _currentImageIndex;
        readonly string[] imageExtensions = { ".jpg", ".jpeg", ".jfif", ".pjpeg", ".pjp", ".png", ".apng", ".bmp", ".ico", ".cur", ".gif", ".tif", ".tiff", ".exif", ".raw" };


        bool IsMaximized
        {
            get 
            { 
                return Settings.Default.IsMaximized;
            }
            set
            { 
                Settings.Default.IsMaximized = value;
            }
        }
        void BtnOpenImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Obrazy (*.jpg;*.jpeg;*.jfif;*.pjpeg;*.pjp;*.png;*.apng;*.bmp;*.ico;*.cur;*.gif;*.tif;*.tiff;*.exif;*.raw)|*.jpg;*.jpeg;*.jfif;*.pjpeg;*.pjp;*.png;*.apng;*.bmp;*.ico;*.cur;*.gif;*.tif;*.tiff;*.exif;*.raw",
                Multiselect = true,
                Title = "Wybierz zdjęcie"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _imagePaths = openFileDialog.FileNames;
                ViewImage();
            }
            EnableOrDisableStopViewingImageButton();
            EnableOrDisableNextOrPreviousButton();
        }

        void BtnStopViewingImage_Click(object sender, EventArgs e)
        {
            pbDisplay.Image = null;
            btnPreviousImage.Enabled = false;
            btnNextImage.Enabled = false;
            btnStopViewingImage.Enabled = false;
        }

       
        void AllowDroppingImagesOrFolderToPictureBox()
        {
            pbDisplay.AllowDrop = true;

            pbDisplay.DragEnter += (s, e) =>
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                    if (files.Length > 0 && (Directory.Exists(files[0]) || IsImageFile(files[0])))
                        e.Effect = DragDropEffects.Copy;
                    else
                        e.Effect = DragDropEffects.None;
                }
                else
                    e.Effect = DragDropEffects.None;
            };

            
            pbDisplay.DragDrop += (s, e) =>
            {
                try
                {
                    string[] filesAndFolders = (string[])e.Data.GetData(DataFormats.FileDrop);

                    // Lista do przechowywania wszystkich ścieżek do obrazów
                    List<string> imagePathsList = new List<string>();

                    // Przejdź przez wszystkie przeciągnięte elementy
                    foreach (string item in filesAndFolders)
                    {
                        // Jeśli to folder, pobierz wszystkie obrazy z folderu
                        if (Directory.Exists(item))
                        {
                            string[] imageFiles = Directory.GetFiles(item, "*.*", SearchOption.TopDirectoryOnly)
                                .Where(file => imageExtensions.Contains(Path.GetExtension(file).ToLower()))
                                .ToArray();

                            if (imageFiles.Length > 0)
                                imagePathsList.AddRange(imageFiles); // Dodaj obrazy do listy
                        }
                        // Jeśli to plik, sprawdź czy jest to obsługiwany obraz
                        else if (IsImageFile(item))
                            imagePathsList.Add(item); // Dodaj plik do listy
                    }

                    // Jeśli lista obrazów nie jest pusta, wyświetl z niej obrazy
                    if (imagePathsList.Count > 0)
                    {
                        _imagePaths = imagePathsList.ToArray();
                        _currentImageIndex = 0;
                        ViewImage(); // Wyświetl pierwszy obraz
                        EnableOrDisableStopViewingImageButton();
                        EnableOrDisableNextOrPreviousButton();
                    }
                    else
                        MessageBox.Show("Brak obsługiwanych obrazów w przeciągniętych elementach.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Błąd odczytu folderu lub pliku.\nTreść wyjątku: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

        }

        bool IsImageFile(string filePath)
        {
            
            string extension = Path.GetExtension(filePath).ToLower();
            return imageExtensions.Contains(extension);
        }

        void ViewImage()
        {
            try
            {
                pbDisplay.Image = Image.FromFile(_imagePaths[_currentImageIndex]);
            }
            catch (Exception ex)
            {
                if (!Path.IsPathRooted(ex.Message)) //dzięki temu warunkowi po przeciągnięciu katalogu nie jest wyrzucany wyjątek
                { 
                    pbDisplay.Image = null;
                    MessageBox.Show($"Nie można załadować obrazu.\nTreść wyjątku: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void EnableOrDisableNextOrPreviousButton()
        {
            if (_imagePaths != null)
            {
                btnNextImage.Enabled = _imagePaths.Length > 0 && _currentImageIndex + 1 < _imagePaths.Length;
                btnPreviousImage.Enabled = _imagePaths.Length > 0 && _currentImageIndex > 0;
            }
        }
        void EnableOrDisableStopViewingImageButton()
        {
            btnStopViewingImage.Enabled = pbDisplay.Image != null;
        }

        void DeleteTxtFile()
        {
            if (pbDisplay.Image == null)
                System.IO.File.Delete(FileHelper.TxtFileWithLastPhotoPath);
        }


        void BtnManual_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Przycisk \"Wybierz\" umożliwia wybranie obrazu z dysku.\n\nMożna przeciągnąć obrazy lub katalogi z obrazami do ramki zamiast klikania przycisku \"Wybierz\".\n\nPrzyciski \"Poprzedni\" i \"Kolejny\" służą do zmiany aktualnie wyświetlanego obrazu, gdy co najmniej 2 obrazy zostały jednocześnie wybrane lub przeciągnięte.\n\nPrzycisk \"Wyczyść\" przestaje wyświetlać obraz w ramce i resetuje przyciski \"Poprzedni\" i \"Kolejny\".\n\nObrazy z rozszerzeniem .apng wyświetlają się jako statyczne, a nie animowane.\n\nProgram nie obsługuje wyświetlania obrazów w formatach .cr2, .dds, .sgi, .svg, .xwd, .dng, .erf, .heif, .webp., ani skrótów do obrazów (.lnk)", "Instrukcja obsługi", MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        void BtnPreviousImage_Click(object sender, EventArgs e)
        {
            _currentImageIndex--;
            ViewImage();
            EnableOrDisableNextOrPreviousButton();
        }

        void BtnNextImage_Click(object sender, EventArgs e)
        {
            _currentImageIndex++;
            ViewImage();
            EnableOrDisableNextOrPreviousButton();
            pbDisplay.Focus(); //bez tego przycisk "wyczyść" zostaje objęty na niebiesko
        }

        void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_imagePaths != null)
                FileHelper.SerializeToFile(_imagePaths[_currentImageIndex]);
            else
                DeleteTxtFile();
        }

        void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            IsMaximized = WindowState == FormWindowState.Maximized ? true : false;//bez  ? true : false nie zadziała
            Settings.Default.Save();
        }
    }
}
