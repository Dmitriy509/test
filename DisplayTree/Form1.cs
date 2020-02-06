using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DisplayTree
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {


            using (catalogDb db = new catalogDb())
            {

                if (!db.CatalogSet.Any())
                {

                    db.CatalogSet.Add(new Catalog { Id = 1, Description = "volvo description", Name = "VOLVO" });
                    db.CatalogSet.Add(new Catalog { Id = 2, Description = "ER description", Name = "ER" });
                    db.CatalogAggrSet.Add(new Catalog_aggregate { Id = 1, CatalogId = 1, Description = "КПП asdfasf", Name = "КПП", Url = "sdf" });
                    db.CatalogAggrSet.Add(new Catalog_aggregate { Id = 2, CatalogId = 2, Description = "Двигатель asdfasf", Name = "Двигатель", Url = "aaaa" });
                    db.CatalogAggrSet.Add(new Catalog_aggregate { Id = 3, CatalogId = 2, Description = "КПП sdf", Name = "КПП", Url = "cvvv" });
                    db.CatalogModels.Add(new Catalog_model { Id = 1, Catalog_aggregateId = 1, Model = "A635", Description = "aaa", Url = "asdf" });
                    db.CatalogModels.Add(new Catalog_model { Id = 2, Catalog_aggregateId = 2, Model = "M4566", Description = "bbb", Url = "asdf" });
                    db.CatalogModels.Add(new Catalog_model { Id = 3, Catalog_aggregateId = 2, Model = "FG4511", Description = "ccc", Url = "ccacc" });
                    db.CatalogModels.Add(new Catalog_model { Id = 4, Catalog_aggregateId = 3, Model = "T45459", Description = "ddd", Url = "cccc" });
                    db.CatalogModels.Add(new Catalog_model { Id = 5, Catalog_aggregateId = 2, Model = "A77", Description = "iii", Url = "cccc" });
                    db.CatalogSet.Add(new Catalog { Id = 3, Description = "TT description", Name = "TT" });
                    db.CatalogAggrSet.Add(new Catalog_aggregate { Id = 4, CatalogId = 1, Description = "КПП1 sdf", Name = "КПП1", Url = "cvvv" });
                    db.SaveChanges();
                }
            }
        }

        Catalog_level addRow(int? parent_id, string name, string descr, catalogDb db)
        {
            Catalog_level newItem = new Catalog_level { Parent_Id = parent_id, Name = name, Description = descr };
            db.CatalogLevelSet.Add(newItem);
            db.SaveChanges();
            return newItem;
        }

        private void fillTableBtn_Click(object sender, EventArgs e)
        {
            using (catalogDb db = new catalogDb())
            {
                if (!db.CatalogLevelSet.Any())
                {
                    var catalog = db.CatalogSet.ToList();
                    foreach (var item in catalog)
                    {
                        Catalog_level newItem = addRow(null, item.Name, item.Description, db);
                        int newCatalogId = newItem.Id;          
                        var catalog_aggr = db.CatalogAggrSet.Where(u => u.CatalogId == item.Id).ToList();

                        foreach (var item2 in catalog_aggr)
                        {

                            newItem = addRow(newCatalogId, item2.Name, item2.Description, db);
                            int newCatalogAggrId = newItem.Id;
                            var catalog_model = db.CatalogModels.Where(u => u.Catalog_aggregateId == item2.Id).ToList();


                            foreach (var item3 in catalog_model)
                            {
                                newItem = addRow(newCatalogAggrId, item3.Model, item3.Description, db);

                            }

                        }

                    }
                }

            }
        }

        void fillTree(Catalog_level row, ref TreeNode tr, TreeView tv)
        {

            if (row.Parent_Id == null)
            {
                tv.Nodes.Add(row.Id.ToString(), row.Name);
                tr = tv.Nodes[row.Id.ToString()];
            }
            else
            {
                if (tr.Name == row.Parent_Id.ToString())
                {
                    tr.Nodes.Add(row.Id.ToString(), row.Name);
                    tr = tr.Nodes[row.Id.ToString()];
                }
                else
                {
                    //   TreeNode newtr = tr.Parent;
                    tr = tr.Parent;
                    fillTree(row, ref tr, tv);
                    //  tr = newtr;

                }
            }
        }

        private void fillTreeBtn_Click(object sender, EventArgs e)
        {
            catalogTreeView.Nodes.Clear();
            using (catalogDb db = new catalogDb())
            {
                TreeNode tr = null;
                var curLevel = db.CatalogLevelSet.AsNoTracking().OrderBy(v => v.Id).Select(u => u);

                foreach (var i in curLevel)
                {
                    fillTree(i, ref tr, catalogTreeView);
                }
            }
        }

        private void ClearTableBtn_Click(object sender, EventArgs e)
        {
            using (catalogDb db = new catalogDb())
            {
                db.Database.ExecuteSqlCommand("DELETE FROM Catalog_level");
            }
        }
    }
}
