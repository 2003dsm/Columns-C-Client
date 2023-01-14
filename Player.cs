using System;
using System.Drawing;
using System.Windows.Forms;

public class Player
{
    public int ID;
	public Grid grid;

	public Player(Form form, int num)
	{
		grid = new Grid();

		grid.CreateGrid();
		grid.CreateGrid(form, num);

	}


}
