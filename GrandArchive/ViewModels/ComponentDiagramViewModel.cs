using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AvaloniaGraphControl;
using ClosedXML.Excel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GrandArchive.Helpers;
using GrandArchive.Helpers.Attributes;
using GrandArchive.Models.ComponentDiagram;
using GrandArchive.ViewModels.Abstract;

namespace GrandArchive.ViewModels;

[NavigableMenuItem("Components", "OrganizationRegular")]
public partial class ComponentDiagramViewModel : NavigableViewModel
{
    [ObservableProperty] private bool _isBusy;
    [ObservableProperty] private Graph _componentGraph;

    [RelayCommand]
    private async Task LoadGraph()
    {
        IsBusy = true;

        var nodes = new List<ComponentDiagramNode>();
        var path = "Assets\\dhci.xlsx";

        await GoogleSheetsDownloader.DownloadXlsxAsync("1df6cNcidCkgKBJdxSNk8CqRXW2iynMlY4GITQ3rKLpw",
            path,
            "1582373080");

        using (var workbook = new XLWorkbook(path))
        {
            var worksheet = workbook.Worksheet("Crafting Recipes");

            var row = worksheet.Row(2);

            while (!row.IsEmpty())
            {
                var node = new ComponentDiagramNode()
                {
                    RawName = row.Cell("A").Value.ToString(),
                    RawType = row.Cell("B").Value.ToString(),
                    RawComponents = row.Cell("C").Value.ToString(),
                    RawComponentCosts = row.Cell("D").Value.ToString(),
                    RawTotalCost = row.Cell("E").Value.ToString(),
                    RawResult = row.Cell("F").Value.ToString(),
                    RawTimePerUnit = row.Cell("G").Value.ToString(),
                    RawFacilities = row.Cell("H").Value.ToString(),
                    RawDifficulty = row.Cell("I").Value.ToString(),
                    RawDescription = row.Cell("J").Value.ToString()
                };

                nodes.Add(node);
                row = row.RowBelow();
            }
        }

        var graph = new Graph();

        foreach (var node in nodes)
        {
            var components = Regex.Matches(node.RawComponents, @"[0-9]+x (.+)");
            foreach (Match component in components)
            {
                var target = nodes.FirstOrDefault(x => x.RawName == component.Groups[1].Value)
                             ?? new ComponentDiagramNode()
                             {
                                 RawName = component.Groups[1].Value,
                                 RawType = "Raw Resource",
                             };
                graph.Edges.Add(new Edge(target, node));
            }
        }

        ComponentGraph = graph;
        IsBusy = false;
    }

    public ComponentDiagramViewModel()
    {
        LoadGraph();
    }
}