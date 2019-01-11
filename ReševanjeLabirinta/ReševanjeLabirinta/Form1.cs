using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReševanjeLabirinta
{
    public partial class ReševanjeLabirinta : Form
    {
        class Index
        {
            public int row, column;

            public Index(int r, int c)
            {
                this.row = r;
                this.column = c;
            }

            public static bool operator ==(Index e1, Index e2)
            {
                if (e1.column == e2.column && e1.row == e2.row)
                    return true;
                else
                    return false;
            }
            public static bool operator !=(Index e1, Index e2)
            {
                if (e1.column != e2.column && e1.row != e2.row)
                    return true;
                else
                    return false;
            }
        }
        private static string file;
        private int[,]  matrix;
        private List<int> path;
        private Index root;

        public ReševanjeLabirinta()
        {
            InitializeComponent();
            comboBox.DataSource = loadAlgorithms();
            file = string.Empty;
            path = new List<int>();
        }

        private List<string> loadAlgorithms()
        {
            List<string> collection = new List<string>();
            collection.Add("A*");
            collection.Add("IDE");
            collection.Add("Iskanje v globino");
            collection.Add("Iskanje v širino");
            return collection;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            opnFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            opnFileDialog.FilterIndex = 1;
            opnFileDialog.RestoreDirectory = true;
            opnFileDialog.FileName = "labirint.txt";
            
            if (opnFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var filePath = opnFileDialog.SafeFileName;

                    var fileStream = opnFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        List<List<int>> list = new List<List<int>>();
                        for (int i=0; reader.Peek() >= 0; i++)
                        {
                            var line = reader.ReadLine() + "\n";
                            list.Add(line.Split(',').Select(h => Int32.Parse(h)).ToList());
                            file += line;
                        }

                        lblLabMatrix.Text = file;
                        lblSelectedFile.Text = filePath;
                        toMatrix(list);
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                
            }
        }

        private void toMatrix(List<List<int>> lst)
        {
            int c = lst.Count;
            int r = lst[0].Count;
            matrix = new int[c, r];

            for(int i = 0; i < c; i++)
            {
                for (int z = 0; z < r; z++)
                {
                    var l = lst[i][z];
                    if(l == -2)
                    {
                        root = new Index(i, z);
                    }
                    matrix[i, z] = l;
                }
            }
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            switch ((string)comboBox.SelectedItem)
            {
                case "A*": aStar();
                    break;
                case "Iskanje v globino": Dfs();
                    break;
                case "Iskanje v širino": Bfs(root);
                    break;
                default: break;
            }
        }

        private void Bfs(Index index)
        {
            var mtx = matrix;
            path.Add(mtx[index.row, index.column]);
            List<Index> visited = new List<Index>();
            visited.Add(index);

            List<Index> find = new List<Index>();
            find.Add(index);

            while (find.Count > 0)
            {
                index = find[0];
                find.Remove(index);
                Index up = new Index(index.row - 1, index.column);
                Index down = new Index(index.row + 1, index.column);
                Index right = new Index(index.row, index.column + 1);
                Index left = new Index(index.row, index.column - 1);

                if (up.row >= 0 && visited.Contains<Index>(up))
                {
                    if (mtx[up.row, up.column] >= 0)
                    {
                        path.Add(mtx[up.row, up.column]);
                        find.Add(up);
                        visited.Add(up);
                    }
                    else if (mtx[up.row, up.column] == -3)
                        break;
                }
                if (right.column < mtx.GetLength(1) && !visited.Contains(right))
                {
                    if (mtx[right.row, right.column] >= 0)
                    {
                        path.Add(mtx[right.row, right.column]);
                        find.Add(right);
                        visited.Add(right);
                    }
                    else if (mtx[right.row, right.column] == -3)
                        break;
                }
                if (down.row < mtx.GetLength(0) && !visited.Contains(down))
                {
                    if (mtx[down.row, down.column] >= 0)
                    {
                        path.Add(mtx[down.row, down.column]);
                        find.Add(down);
                        visited.Add(down);
                    }
                    else if (mtx[down.row, down.column] == -3)
                        break;
                }
                if (left.column >= 0 && !visited.Contains(left))
                {
                    if (mtx[left.row, left.column] >= 0)
                    {
                        path.Add(mtx[left.row, left.column]);
                        find.Add(left);
                        visited.Add(left);
                    }
                    else if (mtx[left.row, left.column] == -3)
                        break;
                }

            }

            for (int i=0; i<path.Count; i++)
            {
                lblSolvedMatrix.Text += path[i] + ",";
            }
        }

        private void Dfs()
        {
            throw new NotImplementedException();
        }

        private void aStar()
        {
            throw new NotImplementedException();
        }

    }
}
