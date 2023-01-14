using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;
using Cliente;

public class Grid
{
    private int[,] grid = new int[6, 12];
    private PictureBox[,] pictureGrid = new PictureBox[6, 12];

    public Grid()
	{
	}

    public void UpdateGrid(int x, int y, int color)
    {
        grid[x, y] = color;

        pictureGrid[x, y].Image = image(grid[x, y]);

    }


    public void CreateGrid(Form form, int num)
    {
        int posX = 10 + ((130 * num) % 780);
        int posY = 10 + (int)((250) * (num / 6));

        for(int i = 0; i < 12; i++)
        {
            for(int e = 0; e < 6; e++)
            {
                pictureGrid[e, i] = new PictureBox();
               pictureGrid[e, i].Image = image(grid[e, i]);
                pictureGrid[e, i].Size = new Size(20, 20);
               pictureGrid[e, i].Location = new Point(posX, posY);

               form.Controls.Add(pictureGrid[e, i]);
                posX += 20;
            }
            posX = 10 + ((130 * num) % 780);
            posY += 20;
        }





    }

    public void CreateGrid()
    {
        for(int x = 0; x < 6;x++)
        {
            for (int y = 0; y < 12; y++)
            {
                grid[x, y] = 0;

            }
        }
    }



    public Image image(int color)
    {

        Image image;
        
        string path = AppDomain.CurrentDomain.BaseDirectory;

        switch (color)
        {
            case 0:
                path += "res\\Bg.jpg";
                break;
            case 2:
                path += "res\\Blue.jpg";

                break;
            case 3:
                path += "res\\Green.jpg";

                break;
            case 1:
                path += "res\\Red.jpg";

                break;
            case 4:
                path += "res\\Joker.jpg";

                break;
            default:
                return null;
        }
        image = Image.FromFile(path);

        // Set the PictureBox's image

        return image;
    }

}
