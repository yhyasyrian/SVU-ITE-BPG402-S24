using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.CodeDom;
using System.Reflection;
using System.Net;

/**
 * Programming Work:
 *  Create desgin 
 *      Create 3 buttons
 *      Create panel
 *  Button DrawPoints: when click enable draw in panel (change property only from false to true)
 *  Button Clear: 
 *      remove any point from array
 *      remove any point from panel (refresh panel for reload draw point)
 *      disable draw
 *  Panel Point Paint:
 *      When Click save point in array
 *      refresh panel, because draw points
 *  Button DeCasteljau:
 *      First draw rectangle
 *      Appley algorithm DeCasteljau
 *      
*/

namespace HomeWork
{
    public partial class HomeWork : Form
    {
        /**
         * Max point can save in array
         */
        const int MAX_POINT = 25;
        /**
         * Max point can draw in panel. (Note: if number large than MAX_POINT the programming will use MAX_POINT as max)
         */
        const int MAX_POINT_CAN_DRAW = 5;
        /**
         * Circle size point
         */
        const int CIRCLE_SIZE = 10;
        /**
         * Font size (size string in panel after draw point)
         */
        const int FONT_SIZE = 10;
        /**
         * Name type font for print point in panel
         */
        const string FONT_NAME = "Arial";
        /**
         * Count point draw as line, for quality line between points if count big, the quality will be good
         */
        const int MAX_POINT_DRAW_FOR_BEZIERCURVES = 70;
        /**
         * Size point when draw rectangle
         */
        const int POINT_RECTANGLE = 3;
        /**
         * Save point here, we use Object Point replace use two array (for x and y)
         */
        Point[] Points = new Point[MAX_POINT];
        /**
         * Current point in draw, and we use it for know count points
         */
        int CurrentPoint = 0;
        /**
         * Status draw, true mean draw is enable
         */
        bool CanDraw = false;
        public HomeWork()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e) { }
        // Helper function for show error message if exists error
        private void ShowError(string exception)
        {
            MessageBox.Show(exception, "Error");
        }
        // Call function when click button "Draw Points"
        private void DrawPoints_Click(object sender, EventArgs e)
        {
            CanDraw = true;
        }
        // Call function when click button "Clear"
        private void Clear_Click(object sender, EventArgs e)
        {
            Array.Clear(Points, 0, MAX_POINT);
            CurrentPoint = 0;
            CanDraw = false;
            PanelPoints.Invalidate();
        }
        // Call function when click button "De Casteljau"
        private void DeCasteljau_Click(object sender, EventArgs e)
        {
            // check if count points less than 2
            if (CurrentPoint < 2)
            {
                ShowError("Please draw two point first");
                return;
            }
            // Draw rectangle
            DrawrRectangle();
            // Draw Bezier curves with algorithm De Casteljau
            BezierCurves();
        }
        private void DrawrRectangle()
        {
            // create variable for maximal x,y and minimal x,y
            Point MaxPoint = new Point(0, 0);
            Point MinPoint = new Point(Points[0].X, Points[0].Y);
            for (int IndexPoint = 0; IndexPoint < CurrentPoint; IndexPoint++)
            {
                // variable for easy access to current point
                Point CurrentPointPointer = Points[IndexPoint];
                if (!MaxPoint.CompareX(CurrentPointPointer))
                {
                    MaxPoint.X = CurrentPointPointer.X;
                }
                if (!MaxPoint.CompareY(CurrentPointPointer))
                {
                    MaxPoint.Y = CurrentPointPointer.Y;
                }
                if (MinPoint.CompareX(CurrentPointPointer))
                {
                    MinPoint.X = CurrentPointPointer.X;
                }
                if (MinPoint.CompareY(CurrentPointPointer))
                {
                    MinPoint.Y = CurrentPointPointer.Y;
                }
            }
            // create variable for draw in panel
            Graphics Graphic = this.PanelPoints.CreateGraphics();
            // create pen with color for draw line
            Brush ColorLine = Brushes.Red;
            /**
             * Draw line from top left to top right
             * Draw line from top left to bottum left
             * Draw line from bottum left to bottum right
             * Draw line from top right to bottum right
             */
            /*
            Pen PenDrow = new Pen(ColorLine);
            Graphic.DrawLine(PenDrow, MinPoint.X, MinPoint.Y, MaxPoint.X, MinPoint.Y);
            Graphic.DrawLine(PenDrow, MinPoint.X, MinPoint.Y, MinPoint.X, MaxPoint.Y);
            Graphic.DrawLine(PenDrow, MinPoint.X, MaxPoint.Y, MaxPoint.X, MaxPoint.Y);
            Graphic.DrawLine(PenDrow, MaxPoint.X, MinPoint.Y, MaxPoint.X, MaxPoint.Y);*/
            // This code can draw rectangle for if we can't use Pen object
            DrawLine(Graphic, ColorLine, MinPoint.X, MinPoint.Y, MaxPoint.X, MinPoint.Y);
            DrawLine(Graphic, ColorLine, MinPoint.X, MinPoint.Y, MinPoint.X, MaxPoint.Y);
            DrawLine(Graphic, ColorLine, MinPoint.X, MaxPoint.Y, MaxPoint.X, MaxPoint.Y);
            DrawLine(Graphic, ColorLine, MaxPoint.X, MinPoint.Y, MaxPoint.X, MaxPoint.Y);
        }
        // This function is replace function Graphic.DrawLine if we can't use Pen object
        private void DrawLine(Graphics Graphic, Brush ColorLine, int StartX, int StartY, int EndX, int EndY)
        {
            bool IsDrawVericle = StartX == EndX;
            if (IsDrawVericle)
            {
                for (int StartDraw=StartY;StartDraw<=EndY;StartDraw++)
                {
                    Graphic.FillEllipse(ColorLine, StartX, StartDraw, POINT_RECTANGLE, POINT_RECTANGLE);
                }
            } else {
                for (int StartDraw = StartX; StartDraw <= EndX; StartDraw++)
                {
                    Graphic.FillEllipse(ColorLine, StartDraw, StartY, POINT_RECTANGLE, POINT_RECTANGLE);
                }
            }
        }
        private void BezierCurves()
        {
            // create variable for draw in panel
            Graphics Graphic = this.PanelPoints.CreateGraphics();
            // costume color 
            Brush ColorCircle = Brushes.Blue;
            for (int i = 1; i <= CurrentPoint; i++)
            {
                // create sub array points for algorithm
                Point[] SubPoints = new Point[i];
                for (int j = 0; j < i; j++)
                {
                    // copy point from source array
                    SubPoints[j] = Points[j];
                }
                // create MAX_POINT_DRAW_FOR_BEZIERCURVES points for line between primary points
                for (int k = 0; k <= MAX_POINT_DRAW_FOR_BEZIERCURVES; k++)
                {
                    // Get point for draw circle in it
                    Point PrintPoint = DeCasteljauAlgorithm((double)k / MAX_POINT_DRAW_FOR_BEZIERCURVES, SubPoints);
                    // draw circle
                    Graphic.FillEllipse(ColorCircle, PrintPoint.X, PrintPoint.Y, CIRCLE_SIZE / 2, CIRCLE_SIZE / 2);
                }
            }
        }
        /**
         * De Casteljau Algorithm: source: https://en.wikipedia.org/wiki/De_Casteljau%27s_algorithm
         */
        private Point DeCasteljauAlgorithm(double t, Point[] coefficients)
        {
            int CountSubArray = coefficients.Length;
            Point[] SubArray = new Point[CountSubArray];
            // copy array
            for (int i = 0; i < CountSubArray; i++)
            {
                Point p = coefficients[i];
                SubArray[i] = new Point(p.X, p.Y);
            }
            for (int i = 1; i < CountSubArray; i++)
            {
                for (int j = 0; j < (CountSubArray - i); j++)
                {
                    SubArray[j].X = Convert.ToInt32(SubArray[j].X * (1 - t) + SubArray[j + 1].X * t);
                    SubArray[j].Y = Convert.ToInt32(SubArray[j].Y * (1 - t) + SubArray[j + 1].Y * t);
                }
            }
            return SubArray[0];
        }
        // Call function when click in panel
        private void PanelPoints_MouseClick(object sender, MouseEventArgs e)
        {
            // if draw is disable
            if (!CanDraw)
            {
                ShowError("Sorry the drow is disable.");
                return;
            }
            // We use Math.Min for get minimal count point for if MAX_POINT_CAN_DRAW large MAX_POINT
            if (CurrentPoint >= Math.Min(MAX_POINT_CAN_DRAW, MAX_POINT))
            {
                ShowError("Sorry you drow maximam points");
                return;
            }
            // Save new point
            Points[CurrentPoint++] = new Point(e.X, e.Y);
            // refersh panel
            PanelPoints.Invalidate();
        }
        // draw points here
        private void PanelPoints_Paint(object sender, PaintEventArgs e)
        {
            Graphics Graphic = e.Graphics;
            Font FontStyle = new Font(FONT_NAME, FONT_SIZE);
            Brush ColorFont = Brushes.Black;
            Brush ColorCircle = Brushes.Red;
            // We get HelfCircle for print center point in center coordinate 
            int HelfCircle = CIRCLE_SIZE / 2;
            for (int IndexPoint = 0; IndexPoint < CurrentPoint; IndexPoint++)
            {
                // Draw circle
                Graphic.FillEllipse(ColorCircle, Points[IndexPoint].X - HelfCircle, Points[IndexPoint].Y - HelfCircle, CIRCLE_SIZE, CIRCLE_SIZE);
                // Draw string (print x and y in panel)
                Graphic.DrawString(Points[IndexPoint].ToString(), FontStyle, ColorFont, Points[IndexPoint].X, Points[IndexPoint].Y + CIRCLE_SIZE / 2);
            }
        }
    }
}
