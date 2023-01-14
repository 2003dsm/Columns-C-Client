using System;
using System.Windows.Forms;
using System.Xml.Linq;

public class Sala
{
    public int ID;
	public Player[] players = new Player[0];
    public Sala()
    {
    }

	public void AddNewPlayer(int id, Form form)
	{
        Player player = new Player(form, players.Length);
        player.ID = id;

        Player[] newList = new Player[players.Length + 1];

        // Copy the elements from the original array to the new array
        Array.Copy(players, newList, players.Length);

        // Add the new element to the new array
        newList[newList.Length - 1] = player;

        // Set the original array to the new array
        players = newList;
    }
}
