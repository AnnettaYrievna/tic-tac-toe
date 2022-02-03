using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace krestikinoliki
{
    class Helper

    {
     
        public static void Print_Mas(DataGridView b, int n, int m)
        {
            //Запрет на вывод заголовочного столбца:
            b.ColumnHeadersVisible = false;
            //Запрет на вывод заголовочной строки:
            b.RowHeadersVisible = false;
            //Установка стиля ячейки: вывод в центр ячейки
            b.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
            b.RowCount = m;/*Количество строк в таблице*/
            b.ColumnCount = n;/* Количество столбцов*/
            for (int i = 0; i <m ; i++)
                for (int j = 0; j < n; j++)
                {
                    if (n >= m)
                    {
                        b.Rows[i].Height = (240 - 2) / n;
                        b.Columns[j].Width = (240 - 2) / n;
                    }
                   else if (n < m)
                    {
                        b.Rows[i].Height = (240 - 2) / m;
                        b.Columns[j].Width = (240 - 2) / m;
                    }
                    b.Rows[i].Cells[j].Value = " ";
                }
        }
    }
}
