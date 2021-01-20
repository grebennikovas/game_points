using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Lastpoints
{
    public partial class Form1 : Form
    {
        // количество точек вдоль оси
        public static int FieldSizeOfPointsX;
        public static int FieldSizeOfPointsY;

        // размер квадрата игрового поля
        public static int SizeOfBox;

        // размеры поля
        public static int PixelsInFieldX;
        public static int PixelsInFieldY;

        // двумерный массив для хранения точек
        public static int[,] points;

        // показывает, чей ход: false - синие, true - красные
        static bool Player;

        // количество поставленных точек
        byte points0;
        byte points1;

        // true - окно настроек открыто, false - закрыто
        public static bool settingsOpen = false;

        // Последняя поставленная точка на игровом поле
        private Point LastPoint;

        // Инициализация пустого игрового поля
        public static PictureBox GameBox = new PictureBox();

        // Создание формы - окна приложения
        public Form1()
        {
            InitializeComponent();
        }

        // Обработчик нажатий на игровое поле
        private void GameBox_Click(object sender, EventArgs e)
        {
            // создать точку
            CreatePoint();
        }

        // Обработчик загрузки основной формы - окна приложения
        private void Form1_Load(object sender, EventArgs e)
        {
            /*создание игрового поля*/
            
            LoadField(39, 32, 25); // 39x32 - базовый размер поля для игры в точки
            GameBox.Location = new Point(6, 30); // задать отступы игровому полю: 6 - слева, 30 - сверху
            GameBox.BorderStyle = BorderStyle.FixedSingle; // стиль рамки
            GameBox.BackColor = Color.White; // цвет фона

            /* привязка обработчиков к событиям */

            GameBox.Click += GameBox_Click; // клик
            GameBox.MouseMove += GameBox_MouseMove; // изменение полложения курсора
            GameBox.Paint += GameBox_Paint; // перерисовка поля
            GameBox.SizeChanged += GameBox_SizeChanged; // изменение размеров поля

            /* настройка окна приложения */

            this.Controls.Add(GameBox); // добавить поле на окно
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // Не позволяет пользователю менять размеры формы
            this.MaximizeBox = false; // Возможность открытия формы на весь экран - false
        }

        // Создает поле заданного размера
        public static void LoadField(int sizeX, int sizeY, int sizeBox) 
        {
            /* установка размеров в глобальные переменные */

            FieldSizeOfPointsX = sizeX;
            FieldSizeOfPointsY = sizeY;
            SizeOfBox = sizeBox;
            PixelsInFieldX = FieldSizeOfPointsX * SizeOfBox;
            PixelsInFieldY = FieldSizeOfPointsY * SizeOfBox;
            GameBox.Size = new Size(PixelsInFieldX, PixelsInFieldY);
            points = new int[FieldSizeOfPointsX, FieldSizeOfPointsY];
            // поставть начальные точки
            SetStart();
        }

        // Устанавливает новые размеры окна
        private void GameBox_SizeChanged(object sender, EventArgs e)
        {
            this.Height = GameBox.Height + 40 + 24 + 12; // 40 - размер панели окна windows, 24 - размер меню, 12 - отступы
            this.Width = GameBox.Width + 28;
        }

        // Обновляет игровое поле
        private void GameBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            DrawLines(g); // Рисует серые линии - разметку игрового поля
            ShiningEllipse(g); // подсвечивает точку под курсором
            DrawPoints(g); // рисует все точки игроков
            RefreshLabel(); // обновляет строку со счётом игры
        }
        // Перерисовка окна
        private void GameBox_MouseMove(object sender, MouseEventArgs e)
        {
            Refresh();
        }

        // Создание линий игрового поля
        private void DrawLines(Graphics g) 
        {
            /* создание вертикальных и горизонтальных линий */
            for (int i = 0; i < FieldSizeOfPointsY; i++)
            {
                g.DrawLine(Pens.Gray, 0, SizeOfBox * i + SizeOfBox / 2, PixelsInFieldX, SizeOfBox * i + SizeOfBox / 2); //отступы в 2 раза меньше размера квадрата
            }
            for (int i = 0; i < FieldSizeOfPointsX; i++)
            {
                g.DrawLine(Pens.Gray, SizeOfBox * i + SizeOfBox / 2, 0, SizeOfBox * i + SizeOfBox / 2, PixelsInFieldY);
            }
        }

        // Возвращает координату точки, на которую наведена мышь
        private Point PointUnderMouse() 
        {
            // Преобразование координат мыши относительно окна windows в целочисленные координаты точек
            int x = ((PointToClient(MousePosition).X - GameBox.Location.X) / SizeOfBox);
            int y = ((PointToClient(MousePosition).Y - GameBox.Location.Y) / SizeOfBox);
            return new Point(x, y);
        }

        // Возвращает прямоугольник, над которым находится мышка
        // В этот прямоугольник помещена точка
        private Rectangle RectangleUnderMouse() 
        {
            Point point = new Point(PointUnderMouse().X * SizeOfBox + SizeOfBox / 4, PointUnderMouse().Y * SizeOfBox + SizeOfBox / 4);
            Size size = new Size(SizeOfBox / 2, SizeOfBox / 2);
            return new Rectangle(point, size);
        }

        // Подсвечивает точку под курсором
        private void ShiningEllipse(Graphics g) 
        {
            Point point = PointUnderMouse();
            if (point.X >= 0 && point.Y >= 0 && point.X < FieldSizeOfPointsX && point.Y < FieldSizeOfPointsY && points[point.X, point.Y] == 0)
            {
                Pen color = Pens.Blue;
                if (Player)
                {
                    color = Pens.Red;
                }
                g.DrawEllipse(color, RectangleUnderMouse());
            }
        }

        // Возвращает координаты точки по ее целочисленному положению
        private Point GetPlace(int x, int y) 
        {
            Point point = new Point();
            point.X = x * SizeOfBox + SizeOfBox / 2;
            point.Y = y * SizeOfBox + SizeOfBox / 2;
            return point;
        }

        // Отрисовка всех точек и границ из массива точек
        private void DrawPoints(Graphics g) 
        {
            //счетчики количества точек синего и красного игроков
            points0 = 0; 
            points1 = 0;
            for (int y = 0; y < FieldSizeOfPointsY; y++)
            {
                for (int x = 0; x < FieldSizeOfPointsX; x++)
                {
                    DrawPoint(g, x, y); // рисует точку в объект Graphics (x,y)
                    DrawBorder(g, x, y); // рисует соединение рядом с точкой в объект Graphics (x,y)
                    if (points[x, y] == -4)
                    {
                        points1++;
                    }
                    if (points[x, y] == -3)
                    {
                        points0++;
                    }
                }
            }
        }

        // Отрисовка точки по координате в объект Graphics (x,y)
        private void DrawPoint(Graphics g, int x, int y) 
        {
            if (PointAdded(x, y))
            {
                // Определить цвет точки по координате
                Brush color = GetColor(x, y);
                g.FillEllipse(color, x * SizeOfBox + SizeOfBox / 4, y * SizeOfBox + SizeOfBox / 4, SizeOfBox / 2, SizeOfBox / 2);
            }
        }
        // Отрисовка соединений между точками
        private void DrawBorder(Graphics g, int x, int y) 
        {
            if (PointAdded(x, y))
            {
                int sizeX = FieldSizeOfPointsX; // размер поля по Х
                int sizeY = FieldSizeOfPointsY; // размер поля по Y
                Pen pen = new Pen(GetColor(x, y));
                pen.Width = SizeOfBox / 8; // толщина линии соединения
                if (y != sizeY && isAlly(x, y, x + 1, y)) //горизонтальная линия
                {
                    g.DrawLine(pen, GetPlace(x, y), GetPlace(x + 1, y));
                }
                if (x != sizeX && isAlly(x, y, x, y + 1)) // вертикальная линия
                {
                    g.DrawLine(pen, GetPlace(x, y), GetPlace(x, y + 1));
                }
                if (y != sizeY && x != sizeX && isAlly(x, y, x + 1, y + 1) && (hisZone(x, y, x + 1, y) ^ hisZone(x, y, x, y + 1)))
                {
                    g.DrawLine(pen, GetPlace(x, y), GetPlace(x + 1, y + 1)); // направо вниз (соединение типа \)
                }
                if (y != sizeY && x != 0 && isAlly(x, y, x - 1, y + 1) && (hisZone(x, y, x - 1, y) ^ hisZone(x, y, x, y + 1)))
                {
                    g.DrawLine(pen, GetPlace(x, y), GetPlace(x - 1, y + 1)); // налево вниз (соединение типа /)
                }
            }
        }
        // Проверяет, являются ли две точки союзниками
        private bool isAlly(int x1, int y1, int x2, int y2) 
        {
            if (x2 == -1 || y2 == -1 || x2 == FieldSizeOfPointsX || y2 == FieldSizeOfPointsY)
            {
                return false;
            }
            return PointAdded(x1, y1) && PointAdded(x2, y2) && (points[x1, y1] % 2 == points[x2, y2] % 2);
        }

        // Проверяет, принадлежит ли позиция (х2;у2) точке с координатами (х,у)
        private bool hisZone(int x1, int y1, int x2, int y2) 
        {
            if (x2 == -1 || y2 == -1 || x2 == FieldSizeOfPointsX || y2 == FieldSizeOfPointsY)
            {
                return false;
            }
            return isAlly(x1, y1, x2, y2) || (AlivePointIs(false, x1, y1) && (points[x2, y2] == 2 || points[x2, y2] == -1 || points[x2, y2] == -3)) || (AlivePointIs(true, x1, y1) && (points[x2, y2] == 1 || points[x2, y2] == -2 || points[x2, y2] == -4));
        }

        // Возвращает цвет точки по заданным координатам 
        private Brush GetColor(int x, int y) 
        {
            // 4 цвета - Красный, Синий, Красный мертвый, Синий мертвый
            if (DeadPointIs(true, x, y))
            {
                return new SolidBrush(Color.FromArgb(233, 133, 133));
            }
            if (DeadPointIs(false, x, y))
            {
                return new SolidBrush(Color.FromArgb(133, 133, 233));
            }
            if (AlivePointIs(true, x, y))
            {
                return Brushes.Red;
            }
            if (AlivePointIs(false, x, y))
            {
                return Brushes.Blue;
            }
            return Brushes.Black;
        }

        // Возвращает true, если на данной позиции стоит точка
        private bool PointAdded(int x, int y) 
        {
            return DeadPointIs(true, x, y) || DeadPointIs(false, x, y) || AlivePointIs(true, x, y) || AlivePointIs(false, x, y);
        }

        // Срабатывает при нажатии на игровое пле
        private void CreatePoint() 
        {
            Point mouse = PointUnderMouse(); // индексы позиции, находящейся под курсором
            if (points[mouse.X, mouse.Y] == 0) // если нажатие произошло на пустую позицию
            {
                AddPoint(mouse.X, mouse.Y);          // добавляет точку соответствующего игрока
                CheckPointsAround(mouse.X, mouse.Y); // проверяет, является ли эта точка последней в окружении
                FindLap(mouse.X, mouse.Y, !Player);  // проверяет, поставлена ли эта точка внутрь окружения противника
                LastPoint = new Point(mouse.X, mouse.Y);
                Step();                              // смена игрока, игровой ход
                EndGame();                           // завершает игру, если на поле не осталось свободных мест
            }
        }
        
        private void AddPoint(int x, int y)
        {
            if (Player)
            {
                points[x, y] = 3;
            }
            else
            {
                points[x, y] = 4;
            }
        }
        private void Step()
        {
            Player = !Player;
        } //смена шага
        private bool AlivePointIs(bool whose, int x, int y) //показывает, есть ли живая точка игрока по координатам
        {
            if (points[x, y] <= 0)
            {
                return false;
            }
            else
            {
                int tail = 0;
                if (whose)
                {
                    tail = 1;
                }
                if (points[x, y] > 2 && points[x, y] % 2 == tail)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        private bool DeadPointIs(bool whose, int x, int y) //показывает, есть ли мертвая точка игрока по координатам
        {
            if (points[x, y] >= -2)
            {
                return false;
            }
            else
            {
                int tail = 0;
                if (whose)
                {
                    tail = -1;
                }
                if (points[x, y] < 2 && points[x, y] % 2 == tail)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        private void CheckPointsAround(int x, int y) // проверка точек вокруг точки с заданными координатами на наличие окружения 
        {
            bool Killer = Player;
            if (x != 0)
            {
                FindLap(x - 1, y, Killer);
                if (y != 0)
                {
                    FindLap(x - 1, y - 1, Killer);
                }
                if (y != FieldSizeOfPointsY - 1)
                {
                    FindLap(x - 1, y + 1, Killer);
                }
            }
            if (x != FieldSizeOfPointsX - 1)
            {
                FindLap(x + 1, y, Killer);
                if (y != 0)
                {
                    FindLap(x + 1, y - 1, Killer);
                }
                if (y != FieldSizeOfPointsY - 1)
                {
                    FindLap(x + 1, y + 1, Killer);
                }
            }
            if (y != 0)
            {
                FindLap(x, y - 1, Killer);
            }
            if (y != FieldSizeOfPointsY - 1)
            {
                FindLap(x, y + 1, Killer);
            }
        }
        private void FindLap(int x, int y, bool Killer) //проверяет, является ли эта точка частью убитой зоны
        {
            bool isLap = true;
            bool[,] victims = new bool[FieldSizeOfPointsX, FieldSizeOfPointsY]; // массив с проверенными позициями
            Stack<Point> stack = new Stack<Point>();
            if (AlivePointIs(!Killer, x, y) || points[x, y] == 0) // проверка
            {
                stack.Push(new Point(x, y));
            }
            else
            {
                return;
            }
            while (stack.Count != 0)
            {
                Point current = stack.Pop();
                victims[current.X, current.Y] = true;
                if (current.X == 0 || current.Y == 0 || current.X == FieldSizeOfPointsX - 1 || current.Y == FieldSizeOfPointsY - 1)
                {
                    isLap = false;
                    break;
                }
                if (!victims[current.X - 1, current.Y] && (points[current.X - 1, current.Y] == 0 || !AlivePointIs(Killer, current.X - 1, current.Y)))
                {
                    stack.Push(new Point(current.X - 1, current.Y)); // проверка позиции слева
                }
                if (!victims[current.X, current.Y - 1] && (points[current.X, current.Y - 1] == 0 || !AlivePointIs(Killer, current.X, current.Y - 1)))
                {
                    stack.Push(new Point(current.X, current.Y - 1)); // проверка позиции сверху
                }
                if (!victims[current.X + 1, current.Y] && (points[current.X + 1, current.Y] == 0 || !AlivePointIs(Killer, current.X + 1, current.Y)))
                {
                    stack.Push(new Point(current.X + 1, current.Y)); // проверка позиции справа
                }
                if (!victims[current.X, current.Y + 1] && (points[current.X, current.Y + 1] == 0 || !AlivePointIs(Killer, current.X, current.Y + 1)))
                {
                    stack.Push(new Point(current.X, current.Y + 1)); // проверка позиции снизу
                }
            }
            if (isLap)
            {
                int sum = 0;
                for (int i = 0; i < FieldSizeOfPointsY; i++)
                {
                    for (int j = 0; j < FieldSizeOfPointsX; j++)
                    {
                        if (victims[j, i] && AlivePointIs(!Killer, j, i))
                        {
                            sum++;
                        }
                    }
                }
                if (sum == 0)
                {
                    return;
                }
                for (int i = 0; i < FieldSizeOfPointsY; i++)
                {
                    for (int j = 0; j < FieldSizeOfPointsX; j++)
                    {
                        if (victims[j, i] && points[j, i] > -5)
                        {
                            points[j, i] = 0 - points[j, i];
                        }
                        if (victims[j, i] && points[j, i] == 0 && Killer)
                        {
                            points[j, i] = 1;
                        }
                        if (victims[j, i] && points[j, i] == 0 && !Killer)
                        {
                            points[j, i] = 2;
                        }
                    }
                }
            }
        }
        private void RefreshLabel()
        {
            string pl;
            if (Player)
            {
                pl = "красных";
            }
            else
            {
                pl = "синих";
            }
            InfoLabel.Text = points0 + ":" + points1 + "   |   " + "Ход " + pl;
        } // Обновляет строку с информацией
        public static void SetStart() // ставит начальные точки
        {
            points[FieldSizeOfPointsX / 2 - 1, FieldSizeOfPointsY / 2 - 1] = 3;
            points[FieldSizeOfPointsX / 2, FieldSizeOfPointsY / 2 - 1] = 4;
            points[FieldSizeOfPointsX / 2 - 1, FieldSizeOfPointsY / 2] = 4;
            points[FieldSizeOfPointsX / 2, FieldSizeOfPointsY / 2] = 3;
            Player = false;
        }
        private bool isEnd() // возвращает true, если на поле не осталось свободных точек
        {
            for (int y = 0; y < FieldSizeOfPointsY; y++)
            {
                for (int x = 0; x < FieldSizeOfPointsX; x++)
                {
                    if (points[x, y] == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private void EndGame() // завершает игру, если на поле не осталось свободных мест
        {
            if (isEnd())
            {
                string who = "Ничья.";
                if (points0 > points1)
                {
                    who = "Победил синий игрок";
                }
                if (points0 < points1)
                {
                    who = "Победил красный игрок";
                }
                MessageBox.Show("Игра окончена. " + who, "Game over!");
            }
        }
        private void Restart_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < FieldSizeOfPointsY; y++)
            {
                for (int x = 0; x < FieldSizeOfPointsX; x++)
                {
                    points[x, y] = 0;
                }
            }
            SetStart();
        }
        private void Settings_Click(object sender, EventArgs e)
        {
            Form2 settings = new Form2();
            if (!settingsOpen)
            {
                settings.Show();
                Point point = new Point();
                point.X = this.Location.X + this.Width / 2 - settings.Width / 2;
                point.Y = this.Location.Y + this.Height / 2 - settings.Height / 2;
                settings.Location = point;
            }
        }
        private void Spravka_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Основная задача - окружить точки противника. Игра длится, пока на поле остаются пустые зоны.", "Правила игры в точки");
        }
        private void Info_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Игра \"Точки\". 2019. Гребенников Андрей. РТУ МИРЭА. БСБО-15-18.");
        }
    }
}
