using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{    public struct Loc{
    public int X;
    public int Y;

    public Loc(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }
}
   public interface InterfaceTTT
    {
        void NewGame(int L,int W, int KW, int type);
        Loc NextRound(Loc L);
        int Result { get;}
        string Name { get; }
    }
}
