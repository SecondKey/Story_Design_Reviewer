using Aga.Diagrams;
using Aga.Diagrams.Controls;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace Story_Design_Reviewer
{
    class FlowDiagramViewModel : ViewModelBase, IDiagramController
    {
        /// <summary>
        /// 更新范围
        /// </summary>
        private class UpdateScope : IDisposable
        {
            private FlowDiagramViewModel _parent;
            public bool IsInProgress { get; set; }

            public UpdateScope(FlowDiagramViewModel parent)
            {
                _parent = parent;
            }

            public void Dispose()
            {
                IsInProgress = false;
                _parent.UpdateView();
            }
        }


        /// <summary>
        /// 对应流程图显示的界面
        /// </summary>
        private DiagramView _view;
        /// <summary>
        /// 对应的一个视图模型（一个事件或包含有图模型的ProcessElement）
        /// 一个Element对应一个模型
        /// </summary>
        private IContainsElements _model;
        /// <summary>
        /// 用于多线程的更新范围
        /// </summary>
        UpdateScope updateScope;

        /// <summary>
        /// 更新视图
        /// </summary>
        private void UpdateView()
        {
            if (!updateScope.IsInProgress)
            {
                _view.Children.Clear();
                foreach (var node in _model.Nodes)
                    _view.Children.Add(UpdateNode(node, null));

                foreach (var link in _model.Links)
                    _view.Children.Add(CreateLink(link));
            }
        }

        /// <summary>
        /// 在视图层面更新节点
        /// 用node更新item
        /// 传入item为空则创建
        /// </summary>
        /// <param name="node"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        private Node UpdateNode(ProcessElementInDiagram node, ProcessElementNode item)
        {
            if (item == null)
            {
                CreatePorts(node, item);
                item.Content = CreateContent(node);
            }
            item.Width = _view.GridCellSize.Width - 20;
            item.Height = _view.GridCellSize.Height - 50;
            item.CanResize = false;
            //TODO:
            //item.SetValue(Canvas.LeftProperty, node.Column * _view.GridCellSize.Width + 10);
            //item.SetValue(Canvas.TopProperty, node.Row * _view.GridCellSize.Height + 25);
            return item;
        }



        /// <summary>
        /// 在视图层面创建一个新的节点的内容
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static FrameworkElement CreateContent(ProcessElementInDiagram node)
        {
            var textBlock = new TextBlock()
            {
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center
            };
            var b = new Binding("Text");
            b.Source = node;
            textBlock.SetBinding(TextBlock.TextProperty, b);

            //TODO:
            //if (node.Kind == NodeKinds.Start || node.Kind == NodeKinds.End)
            //{
            //    var ui = new Border();
            //    ui.CornerRadius = new CornerRadius(15);
            //    ui.BorderBrush = Brushes.Black;
            //    ui.BorderThickness = new Thickness(1);
            //    ui.Background = Brushes.Yellow;
            //    ui.Child = textBlock;
            //    return ui;
            //}
            //else if (node.Kind == NodeKinds.Action)
            //{
            //    var ui = new Border();
            //    ui.BorderBrush = Brushes.Black;
            //    ui.BorderThickness = new Thickness(1);
            //    ui.Background = Brushes.Lime; ;
            //    ui.Child = textBlock;
            //    return ui;
            //}
            //else
            //{
            //    var ui = new Path();
            //    ui.Stroke = Brushes.Black;
            //    ui.StrokeThickness = 1;
            //    ui.Fill = Brushes.Pink;
            //    var converter = new GeometryConverter();
            //    ui.Data = (Geometry)converter.ConvertFrom("M 0,0.25 L 0.5 0 L 1,0.25 L 0.5,0.5 Z");
            //    ui.Stretch = Stretch.Uniform;

            //    var grid = new Grid();
            //    grid.Children.Add(ui);
            //    grid.Children.Add(textBlock);

            //    return grid;
            //}
            return null;
        }

        /// <summary>
        /// 在视图层面创建一个端口
        /// </summary>
        /// <param name="node"></param>
        /// <param name="item"></param>
        private void CreatePorts(ProcessElementInDiagram node, Node item)
        {
            foreach (var kind in node.GetPorts())
            {
                var port = new Aga.Diagrams.Controls.EllipsePort();
                port.Width = 10;
                port.Height = 10;
                port.Margin = new Thickness(-5);
                port.Visibility = Visibility.Visible;
                port.VerticalAlignment = ToVerticalAligment(kind);
                port.HorizontalAlignment = ToHorizontalAligment(kind);
                port.CanAcceptIncomingLinks = kind == PortType.Top;
                port.CanAcceptOutgoingLinks = !port.CanAcceptIncomingLinks;
                port.Tag = kind;
                port.Cursor = Cursors.Cross;
                port.CanCreateLink = true;
                item.Ports.Add(port);
            }
        }

        /// <summary>
        /// 在视图层面创建一个连接线
        /// </summary>
        /// <param name="link">一个连接的实例</param>
        /// <returns></returns>
        private Control CreateLink(LinkViewModel link)
        {
            var item = new OrthogonalLink();
            item.ModelElement = link;
            item.EndCap = true;
            item.Source = FindPort(link.Source, link.SourcePort);
            item.Target = FindPort(link.Target, link.TargetPort);

            var b = new Binding("Text");
            b.Source = link;
            item.SetBinding(LinkBase.LabelProperty, b);

            return item;
        }

        /// <summary>
        /// 查找一个端口
        /// </summary>
        /// <param name="node"></param>
        /// <param name="portKind"></param>
        /// <returns></returns>
        private IPort FindPort(ProcessElementViewModel node, PortType portKind)
        {
            var inode = _view.Items.FirstOrDefault(p => p.ModelElement == node) as Aga.Diagrams.Controls.INode;
            if (inode == null)
                return null;
            var port = inode.Ports.OfType<FrameworkElement>().FirstOrDefault(
                p => p.VerticalAlignment == ToVerticalAligment(portKind)
                    && p.HorizontalAlignment == ToHorizontalAligment(portKind)
                );
            return (Aga.Diagrams.Controls.IPort)port;
        }

        /// <summary>
        /// 通过端口类型获取一个端口的纵向布局属性
        /// </summary>
        /// <param name="kind"></param>
        /// <returns></returns>
        private VerticalAlignment ToVerticalAligment(PortType kind)
        {
            if (kind == PortType.Top)
                return VerticalAlignment.Top;
            if (kind == PortType.Bottom)
                return VerticalAlignment.Bottom;
            else
                return VerticalAlignment.Center;
        }

        /// <summary>
        /// 通过端口类型获取一个端口的纵向布局属性
        /// </summary>
        /// <param name="kind"></param>
        /// <returns></returns>
        private HorizontalAlignment ToHorizontalAligment(PortType kind)
        {
            if (kind == PortType.Left)
                return HorizontalAlignment.Left;
            if (kind == PortType.Right)
                return HorizontalAlignment.Right;
            else
                return HorizontalAlignment.Center;
        }

        /// <summary>
        /// 删除当前选择的节点或连接
        /// </summary>
        private void DeleteSelection()
        {
            using (BeginUpdate())
            {
                var nodes = _view.Selection.Select(p => p.ModelElement as ProcessElementInDiagram).Where(p => p != null);
                var links = _view.Selection.Select(p => p.ModelElement as LinkViewModel).Where(p => p != null);
                _model.Nodes.RemoveRange(p => nodes.Contains(p));
                _model.Links.RemoveRange(p => links.Contains(p));
                _model.Links.RemoveRange(p => nodes.Contains(p.Source.proxyNode) || nodes.Contains(p.Target.proxyNode));
                List<int> t = new List<int>();
            }
        }

        /// <summary>
        /// 开始更新
        /// </summary>
        /// <returns></returns>
        private IDisposable BeginUpdate()
        {
            updateScope.IsInProgress = true;
            return updateScope;
        }


        #region IDiagramController Members
        public void UpdateItemsBounds(Aga.Diagrams.Controls.DiagramItem[] items, Rect[] bounds)
        {
            for (int i = 0; i < items.Length; i++)
            {
                var node = items[i].ModelElement as ProcessElementNode;
                if (node != null)
                {
                    //TODO:
                    //node.Column = (int)(bounds[i].X / _view.GridCellSize.Width);
                    //node.Row = (int)(bounds[i].Y / _view.GridCellSize.Height);
                }
            }
        }

        public void UpdateLink(LinkInfo initialState, ILink link)
        {
            using (BeginUpdate())
            {
                var sourcePort = link.Source as PortBase;
                var source = VisualHelper.FindParent<Node>(sourcePort);
                var targetPort = link.Target as PortBase;
                var target = VisualHelper.FindParent<Node>(targetPort);

                _model.Links.Remove((link as LinkBase).ModelElement as LinkViewModel);
                _model.Links.Add(
                    new LinkViewModel((ProcessElementViewModel)source.ModelElement, (PortType)sourcePort.Tag,
                        (ProcessElementViewModel)target.ModelElement, (PortType)targetPort.Tag)
                        );
            }
        }

        public void ExecuteCommand(System.Windows.Input.ICommand command, object parameter)
        {
            if (command == ApplicationCommands.Delete)
                DeleteSelection();
        }

        public bool CanExecuteCommand(System.Windows.Input.ICommand command, object parameter)
        {
            if (command == ApplicationCommands.Delete)
                return true;
            else
                return false;
        }

        void IDiagramController.UpdateItemsBounds(DiagramItem[] items, Rect[] bounds)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
    static class ControllerHealper
    {
        public static void RemoveRange<T>(this ICollection<T> source, Func<T, bool> predicate)
        {
            var arr = source.Where(p => predicate(p)).ToArray();
            foreach (var t in arr)
                source.Remove(t);
        }
    }
}
