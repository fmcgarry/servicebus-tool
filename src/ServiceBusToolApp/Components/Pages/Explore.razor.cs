using MudBlazor;

namespace ServiceBusToolApp.Components.Pages;

public partial class Explore
{
    private HashSet<TreeItemData> TreeItems { get; set; } = new HashSet<TreeItemData>();

    public async Task<HashSet<TreeItemData>> LoadServerData(TreeItemData parentNode)
    {
        await Task.Delay(500);
        return parentNode.TreeItems;
    }

    protected override void OnInitialized()
    {
        TreeItems.Add(new TreeItemData("All Mail", Icons.Material.Filled.Email));
        TreeItems.Add(new TreeItemData("Trash", Icons.Material.Filled.Delete));
        TreeItems.Add(new TreeItemData("Categories", Icons.Material.Filled.Label)
        {
            TreeItems = new HashSet<TreeItemData>()
            {
                new TreeItemData("Social", Icons.Material.Filled.Group, 90),
                new TreeItemData("Updates", Icons.Material.Filled.Info, 2294),
                new TreeItemData("Forums", Icons.Material.Filled.QuestionAnswer, 3566),
                new TreeItemData("Promotions", Icons.Material.Filled.LocalOffer, 733)
            }
        });
        TreeItems.Add(new TreeItemData("History", Icons.Material.Filled.Label, null, false));
    }

    public class TreeItemData
    {
        public TreeItemData(string title, string icon, int? number = null, bool canExpand = true)
        {
            Title = title;
            Icon = icon;
            Number = number;
            CanExpand = canExpand;
        }

        public bool CanExpand { get; set; }
        public string Icon { get; set; }
        public int? Number { get; set; }
        public string Title { get; set; }
        public HashSet<TreeItemData> TreeItems { get; set; }
    }
}