using System.Collections.Generic;
using NexusCore.Common.Data.Models.Page;

namespace NexusCore.Common.Data.Values.Page
{
    public class PageGridTypeValues
    {
        private readonly IEnumerable<PageGridTypeModel> _pageGridTypes;

        public IEnumerable<PageGridTypeModel> Values { get { return _pageGridTypes; } }

        private static PageGridTypeValues _instance;

        public static PageGridTypeValues Instance
        {
            get { return _instance ?? (_instance = new PageGridTypeValues()); }
        }

        public PageGridTypeValues()
        {
            _pageGridTypes = new List<PageGridTypeModel>()
            {
                new PageGridTypeModel()
                {
                    ItemType = PageGridType.Col,
                    TagName = "Col",
                    ClassName = "",
                    OptionalClassName = ".col-md-",
                    Style = "",
                    IsShowOnMenu = true,
                    Constrains = new []
                    {
                        PageGridType.PlaceHolder, 
                        PageGridType.Row                     
                    }
                },
                new PageGridTypeModel()
                {
                    ItemType = PageGridType.Row,
                    TagName = "Row",
                    ClassName = ".row",
                    OptionalClassName = "",
                    Style = "",
                    IsShowOnMenu = true,
                    Constrains = new []
                    {
                        PageGridType.PlaceHolder, 
                        PageGridType.Container,
                        PageGridType.ContainerFluid                     
                    }
                },
                new PageGridTypeModel()
                {
                    ItemType = PageGridType.Container,
                    TagName = "Container",
                    ClassName = ".container",
                    OptionalClassName = "",
                    Style = "",
                    IsShowOnMenu = true,
                    Constrains = new []
                    {
                        PageGridType.PlaceHolder,                        
                    }

                },
                new PageGridTypeModel()
                {
                    ItemType = PageGridType.ContainerFluid,
                    TagName = "ContainerFluid",
                    ClassName = ".container-fluid",
                    OptionalClassName = "",
                    Style = "",
                    IsShowOnMenu = false,
                    Constrains = new []
                    {
                        PageGridType.PlaceHolder,
                    }
                },
                new PageGridTypeModel()
                {
                    ItemType = PageGridType.Control,
                    TagName = "",
                    ClassName = "",
                    OptionalClassName = "",
                    Style = "",
                    IsShowOnMenu = false,
                    Constrains = new []
                    {
                        PageGridType.PlaceHolder,
                        PageGridType.Container,
                        PageGridType.ContainerFluid,
                        PageGridType.Row,
                        PageGridType.Col
                    }
                },
            };
        }
    }
}
