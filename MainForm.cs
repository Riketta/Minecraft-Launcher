using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace MinecraftLauncher
{
    public partial class MainForm : Form
    {
        //string ServerIP = "127.0.0.1"; // Адрес веб-сервера Майнкрафта
        string ServerIP = "10.110.33.130"; // Адрес веб-сервера Майнкрафта
        //string ServerIP = "192.168.14.157"; // Адрес веб-сервера Майнкрафта
        string MinecraftPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraft"; // Путь к игре

        string WebSubFolder = "/mc/";
        //string WebSubFolder = "/";

        string MainJar = @"\Main\Main.jar"; // Путь к главному бинарнику
        string MainClass = "net.minecraft.launchwrapper.Launch"; // Основной класс бинарника
        string TweakClass = "cpw.mods.fml.common.launcher.FMLTweaker"; // Анон какой-то

        string LauncherVer = "1_3_Riketta";

        string ConfigFile = "minelauncher.conf";

        string Session = "0"; // Для сессии
        string GameVersion = "1_6_4"; // Версия клиента

        int JavaMemory = 2048; // Предельная память для javaw

        bool IsUpdated = false;
        bool IsSessionNeeded = true;

        bool IsXP = false;

        Thread UpdateThread;

        List<string> Args = new List<string>(); // Список аргументов для java

        public MainForm()
        {
            CheckForIllegalCrossThreadCalls = false; // Разрешаем обращаться к контролам из разных потоков
            InitializeComponent();

            IsXP = WinXP();

            if (IsXP) // Если XP
                MinecraftPath = Directory.GetParent(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)).FullName + @"\.minecraft"; // Меняем путь к игре

            LoadConfig(); // Загружаем конфигурацию лаунчера

            label_ServerAddres.Text = "Специально для http://" + ServerIP + "/"; // Информация о сервере
            webBrowser.Url = new Uri("http://" + ServerIP + WebSubFolder + "lnews.php"); // Страница на новости, RSS

            //Console.WriteLine(MinecraftPath);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private bool WinXP()
        {
            if (Environment.OSVersion.Version.Major == 5)
                return true;
            else return false;
        }

        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try { System.Diagnostics.Process.Start("http://" + ServerIP + WebSubFolder); } // Открыть ссылку регистрации
            catch { }
        }

        private void button_Start_Click(object sender, EventArgs e)
        {
            StartMinecraft(); // Запуск игры
        }

        private void CrashLog(Exception ex)
        {
            StreamWriter ExWriter = new StreamWriter(MinecraftPath + @"\LauncherExLog.txt", true); // Файл для отладки

            ExWriter.WriteLine("################## " + DateTime.Now + " ##################");
            ExWriter.WriteLine(ex.ToString());
            ExWriter.WriteLine("################## - ##################\n\n");

            ExWriter.Close();
        }

        private void StartMinecraft()
        {
            try
            {
                label_Error.Visible = true;

                if (textBox_Login.Text.Length > 0 && textBox_Password.Text.Length > 0) // Если игрок ввел данные
                {
                    label_Error.Text = "Запуск игры... "; // Отчистить поле для ошибок

                    if (!IsUpdated) // Если обновление еще не проходило
                    {
                        button_Start.Enabled = false; // Отключим кнопку, дабы избежать даблкликов
                        button_Start.Text = "Обновление"; // Выведем что сейчас идет обновление

                        UpdateThread = new Thread(ClientUpdate); // Запуск обновления в отдельном потоке
                        UpdateThread.Start();

                        // backgroundWorker.RunWorkerAsync(); // Проверка и загрузка недостающих файлов
                    }
                    else // Если обновлено
                        if (IsSessionNeeded) // Если сессия нужна для онлайн-игры
                            GetSession(); // Получение сессии

                    if (Session != "0" || !IsSessionNeeded) // Если мы успешно получили сессию либо играем оффлайн
                    {
                        System.Diagnostics.Process Minecraft = new System.Diagnostics.Process();

                        if (!IsXP) // Если актуальная система
                        {
                            //SaveConfig(); // Сохраняем параметры
                            //Minecraft.StartInfo.FileName = Environment.SystemDirectory + @"\javaw.exe"; // Запуск явы без консоли
                            Minecraft.StartInfo.FileName = "javaw"; // Запуск явы без консоли
                            Minecraft.StartInfo.Arguments = ArgsInit(); // Инициализируем аргументы
                        }
                        else // Если XP
                        {
                            Minecraft.StartInfo.FileName = @"cmd"; // Запуск системной консоли
                            Minecraft.StartInfo.CreateNoWindow = false; // Прячем окно консоли
                            Minecraft.StartInfo.Arguments = "/c start javaw " + ArgsInit(); // Инициализируем аргументы
                            Console.WriteLine(ArgsInit());
                        }

                        Minecraft.Start(); // Запускаем игру
                        this.Close(); // Закрываем лаунчер
                    }
                }
                else label_Error.Text = "Введите логин и пароль!"; // Если данные не введены
            }
            catch (Exception ex) { label_Error.Text += "Не удалось запустить игру!"; CrashLog(ex); }
        }

        private void ClearLogin()
        {
            button_Start.Text = "Вход";
            button_Start.Enabled = true;

            IsUpdated = false;
            IsSessionNeeded = true;
        }

        private void GetSession()
        {
            // "$last_ver:0:$username:$sessionid";
            // Data[3] - sessions
            try
            {
                // Загружаем страницу для получения сессии, передаем нужные параметры и парсим сессию
                HttpWebRequest Request = (HttpWebRequest)WebRequest.Create("http://" + ServerIP + WebSubFolder + "launcher.php?version=" + LauncherVer + "&user=" + textBox_Login.Text + "&password=" + textBox_Password.Text);
                Request.Timeout = 5000; // Время предельного ожидания соединения 5 секунд
                
                HttpWebResponse Response = (HttpWebResponse)Request.GetResponse();

                StreamReader Reader = new StreamReader(Response.GetResponseStream());
                string html = Reader.ReadLine().Trim();

                Response.Close();
                Reader.Close();

                if (html != "Wrong user or password")
                {
                    if (html != "Old version")
                    {
                        string[] Data = html.Split(':'); // Режем ответ
                        Session = Data[3].Replace("\n", "").Replace("\r", "").Trim(); // Получаем сессию

                        //Console.Write(Session);
                    }
                    else label_Error.Text = "Старая версия лаунчера!";
                }
                else
                {
                    label_Error.Text = "Вы указали неверные данные!";
                    ClearLogin();
                }
            }
            catch (Exception ex) { label_Error.Text = "Невозможно соединиться с " + ServerIP + "! \n Сессия не получена!"; ClearLogin(); CrashLog(ex); } // Избегаем возможной ошибки
        }

        private void LoadConfig()
        {
            if (File.Exists(MinecraftPath + @"\" + ConfigFile)) // Если файл конфига есть, то
            {
                try
                {
                    StreamReader Reader = new StreamReader(MinecraftPath + @"\" + ConfigFile);
                    textBox_Login.Text = Reader.ReadLine().Trim(); // На первой строке - логин
                    textBox_Password.Text = Reader.ReadLine().Trim(); // На второй - пароль
                    JavaMemory = Convert.ToInt32(Reader.ReadLine().Trim()); // На третьей - объем памяти
                    textBox_PersonalArgs.Text = Reader.ReadLine().Trim(); // На четвертой - персональные аргументы
                    Reader.Close(); // Закрываем считывалку

                    textBox_JavaMemory.Text = JavaMemory.ToString();

                    if (textBox_Password.Text.Length > 0)
                    {
                        checkBox.Checked = true; // Установить чекбокс в положительное состояние
                        button_Start.Select(); // Берем в фокус кнопку запуска
                    }
                    else
                        textBox_Password.Select(); // Если пароля нет, фокусируемся на поле ввода пароля

                }
                catch (Exception ex){ label_Error.Text = "Не удалось загрузить настройки!"; CrashLog(ex); } // Игнорировать возможную ошибку
            }
        }

        private void SaveConfig()
        {
            try
            {
                StreamWriter Writer = new StreamWriter(MinecraftPath + @"\" + ConfigFile);
                Writer.WriteLine(textBox_Login.Text); // Записываем логин

                if (checkBox.Checked) // Если сохранение пароля включено
                    Writer.WriteLine(textBox_Password.Text); // Записываем пароль
                else // Если выключено
                    Writer.WriteLine(""); // Записываем null

                Writer.WriteLine(textBox_JavaMemory.Text); // Записываем объем памяти
                Writer.WriteLine(textBox_PersonalArgs.Text); // Записываем персональные аргументы
                Writer.Close();
            }
            catch (Exception ex) { label_Error.Text = "Не удалось сохранить настройки!"; CrashLog(ex); } // Игнорировать возможную ошибку
            //File.Delete(MinecraftPath + @"\" + ConfigFile); // Если файл есть - удалить
        }

        private string ArgsInit()
        {
            Args.Add("-Xmx" + JavaMemory + "m "); // Предельный объем памяти для майнкрафта
            Args.Add("-Dfml.ignorePatchDiscrepancies=true "); // Для измененных файлов
            Args.Add("-Dfml.ignoreInvalidMinecraftCertificates=true "); // Тоже обход защиты
            Args.Add("-Djava.library.path=" + MinecraftPath + @"\versions\Main\natives ");

            // Рекурсивно получить все классы
            //string[] Libs = Directory.GetFiles(MinecraftPath + @"\libraries\", "*.jar", SearchOption.AllDirectories);
            string[] Libs = Directory.GetFiles(MinecraftPath + @"\libraries\", "*.jar", SearchOption.TopDirectoryOnly);
            Args.Add("-cp "); // Добавить флаг -cp
            foreach (string Lib in Libs) // Перебор найденных библиотек
                Args.Add("\"" + Lib + "\"" + ";"); // Добавить все библиотеки к -cp

            Args.Add(MinecraftPath + @"\versions" + MainJar + " " + MainClass + " "); // Бинарный файл Minecraft'а

            Args.Add("--username " + textBox_Login.Text + " ");
            Args.Add("--session " + Session + " ");
            Args.Add("--version " + GameVersion + " ");
            Args.Add("--gameDir " + MinecraftPath + " ");
            Args.Add("--assetsDir " + MinecraftPath + @"\assets" + " ");
            Args.Add("--tweakClass " + TweakClass);

            if (textBox_PersonalArgs.Text.Length > 0) // Если персональные аргументы введены
                Args.Add(textBox_PersonalArgs.Text); // Добавляем персональные аргументы

            string FullArgs = "";
            foreach (string Arg in Args)
                FullArgs += Arg; // Добавим аргумент к списку аргументов

            return FullArgs;
        }

        private void ClientUpdate()
        {
            if (Directory.Exists(MinecraftPath))
                Directory.CreateDirectory(MinecraftPath); // Создать папку игры, если ее нет

            try
            {
                label_Error.Text = "Проверка обновлений.";

                // Загружаем страницу со списком файлов
                HttpWebRequest Request = (HttpWebRequest)WebRequest.Create("http://" + ServerIP + WebSubFolder + "mc/MinecraftDownload/index.php");
                Request.Timeout = 5000; // Время предельного ожидания соединения 5 секунд

                HttpWebResponse Response = (HttpWebResponse)Request.GetResponse();

                StreamReader Reader = new StreamReader(Response.GetResponseStream());
                string html = Reader.ReadToEnd().Trim().TrimEnd('|'); // Удаляем последний лишний |

                html = html.Replace('/', '\\'); // Заменяем не крутые слеши на крутые

                Response.Close(); // Закрываем соединения
                Reader.Close();

                string[] Files = html.Split('|'); // Разделяем все строки и игнорируем пустые

                List<string> ServerMods = new List<string>(); // Список модов сервера
                List<string> ServerLibs = new List<string>(); // Список библиотек сервера

                foreach (string FileData in Files) // Перебираем все файлы и загружаем что нужно
                {
                    string[] FileSplit = FileData.Split(':');

                    string FilePath = FileSplit[0].Replace(@".\files", "").Trim(); // Отделяем путь к файлу и убираем лишнее
                    int FileSize = Convert.ToInt32(FileSplit[1].Trim()); // Отделяем размер файла

                    if (FilePath.StartsWith(@"\mods\")) // Если этот файл - мод
                        ServerMods.Add(FilePath.Replace(@"\mods\", "")); // Добавим его в перечень модов, удалим путь
                    else if (FilePath.StartsWith(@"\libraries\")) // Если этот файл - библиотека
                        ServerMods.Add(FilePath.Replace(@"\libraries\", "")); // Добавим его в перечень библиотек, удалим путь

                    FileInfo Info = new FileInfo(MinecraftPath + FilePath); // Получаем информацию о файле
                    if (!File.Exists(MinecraftPath + FilePath) || Info.Length != FileSize) // Если файла нет или размер не совпал
                    {
                        if (!Directory.Exists(Info.DirectoryName)) // Если такой папки еще нет
                            Directory.CreateDirectory(Info.DirectoryName); // Создадим папку для файла или структуру папок
                        
                        label_Error.Text = "Обновление:\nЗагрузка " + FilePath.TrimStart('\\');
                        File.Delete(MinecraftPath + FilePath); // Удалить этот файл
                        WebClient Downloader = new WebClient(); // Загрузить этот файл

                        Downloader.DownloadFile("http://" + ServerIP + WebSubFolder + "mc/MinecraftDownload/files/" + FilePath.TrimStart('\\'), MinecraftPath + FilePath);
                    }
                }

                string[] ClientMods = Directory.GetFiles(MinecraftPath + @"\mods\"); // Получаем все моды
                foreach (string ClientMod in ClientMods) // Сравниваем моды на сервере и на клиенте, удаляем лишние
                {
                    FileInfo Mod = new FileInfo(ClientMod); // Получаем сам файл
                    bool IsOk = false; // Переменная для сверки, в наличии ли мод

                    foreach (string ServerMod in ServerMods)
                        if (Mod.Name == ServerMod) // Если такой мод найден
                            IsOk = true; // Говорим что его удалять не надо

                    if (!IsOk) // Если такого мода нет
                        File.Delete(ClientMod); // Удаляем мод
                }

                string[] ClientLibs = Directory.GetFiles(MinecraftPath + @"\libraries\"); // Получаем все либы
                foreach (string ClientLib in ClientLibs) // Сравниваем моды на сервере и на клиенте, удаляем лишние
                {
                    FileInfo Lib = new FileInfo(ClientLib); // Получаем сам файл
                    bool IsOk = false; // Переменная для сверки, в наличии ли библиотека

                    foreach (string ServerMod in ServerMods)
                        if (Lib.Name == ServerMod) // Если такая либа на сервере есть
                        {
                            IsOk = true; // Говорим что ее удалять не надо
                            break; // Выходим из цикла
                        }

                    if (!IsOk) // Если такой либы нет
                        File.Delete(ClientLib); // Удаляем ее
                }
            }
            catch (Exception ex) // Ловим возможное исключение
            { 
                label_Error.Text = "Не удалось обновить клиент!";

                button_Start.Enabled = true; // Отключим кнопку, дабы избежать даблкликов
                button_Start.Text = "Играть оффлайн"; // Выведем что сейчас идет обновление

                IsSessionNeeded = false; // Сообщаем игре что сессия не нужна и играть будем оффлайн

                CrashLog(ex);
            } 

            IsUpdated = true; // Ставим флаг обновления в положительное состояние

            StartMinecraft(); // Перезапускаем процесс начала игры

            try { UpdateThread.Abort(); } // Завершаем работу потока
            catch { }

            //try { backgroundWorker.CancelAsync(); } // Завершаем работу потока
            //catch { }
        }

        private void button_Options_Click(object sender, EventArgs e)
        {
            webBrowser.Visible = !webBrowser.Visible; // Переключаем видимость браузера

            if (webBrowser.Visible) // Если браузер видим
                button_Options.Text = "Опции"; // Присвоить кнопке текст "Опции"
            else // Иначе
                button_Options.Text = "Новости"; // Присвоить "Новости"
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveConfig(); // Сохранить настройки при закрытии лаунчера
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            try { System.Diagnostics.Process.Start("http://" + ServerIP + "/"); } // Открыть главную страницу
            catch { }
        }

        private void label_Error_TextChanged(object sender, EventArgs e)
        {
            if (label_Error.Text != "" && !label_Error.Visible) // Если в лейбле для ошибок что-то написано
                label_Error.Visible = true; // Отобразить лейбл
            else if (label_Error.Text == "" && label_Error.Visible)
                label_Error.Visible = false; // Иначе - скрыть
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            ClientUpdate(); // Начинаем обновление в отдельном потоке
        }

        private void textBox_Password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) // Enter
                StartMinecraft(); // Запуск игры
        }

        private void textBox_Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) // Enter
                StartMinecraft(); // Запуск игры
        }
    }
}
