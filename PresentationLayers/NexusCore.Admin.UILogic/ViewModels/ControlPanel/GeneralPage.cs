
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NexusCore.Admin.UILogic.ViewModels.ControlPanel
{
    public class GeneralPage
    {
        public class Meta
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public string Keywords { get; set; }
            public string FavIcon { get; set; }
        }

        public class CssClass
        {
            public string Body { get; set; }
        }

        public class AngularJs
        {
            public bool IsEnabled { get; set; }
            public KeyValuePair<string, string> Controller { get; set; }
            public bool HasInit { get; set; }
            public KeyValuePair<string, string> Init { get; set; }

            public HtmlString HtmlString
            {
                get
                {
                    return new HtmlString(string.Format(" {0} {1}",
                        IsEnabled
                            ? string.Format("ng-controller=\"{0} as {1}\"", Controller.Key,
                                Controller.Value)
                            : "",
                        IsEnabled && HasInit
                            ? string.Format("ng-init=\"{0}({1})\"", Init.Key, Init.Value)
                            : "").TrimEnd());
                }
            }
        }

        public enum MessageType
        {
            Success,
            Info,
            Warning,
            Error
        }

        public class Message
        {
            public class MessageDetail
            {
                public MessageType Level { get; set; }
                public string Title { get; set; }
                public string Text { get; set; }

                public string Css
                {
                    get
                    {
                        switch (Level)
                        {
                            case MessageType.Success:
                                return "alert-success";
                            case MessageType.Info:
                                return "alert-info";
                            case MessageType.Warning:
                                return "alert-warning";
                            case MessageType.Error:
                                return "alert-danger";
                        }
                        return "alert-info";
                    }
                }
            }

            public bool HasMessage { get { return MessageDetails.Any(); } }
            public List<MessageDetail> MessageDetails { get; private set; }

            public Message()
            {
                MessageDetails = new List<MessageDetail>();
            }

        }

        public Meta MetaData { get; set; }
        public CssClass PageClass { get; set; }
        public AngularJs Angular { get; set; }
        public Message InfoBox { get; set; }
        public string Title { get; set; }
        public string TitleDescription { get; set; }
    }

}
