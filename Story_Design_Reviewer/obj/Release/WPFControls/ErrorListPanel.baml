   M S B A M L   `   `   `  ���� c  _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  P LStory_Design_Reviewer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Story_Design_ReviewerStory_Design_Reviewer *   $Story_Design_Reviewer.ErrorListPanel   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     b ^GalaSoft.MvvmLight.Platform, Version=5.4.1.0, Culture=neutral, PublicKeyToken=5f873c45e98af8a1+mvvm http://www.galasoft.ch/mvvmlight  XiPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity  /local#clr-namespace:Story_Design_Reviewer  .command http://www.galasoft.ch/mvvmlight  -   $
��main��  � DataContext  ��    Locator �� Source# [   �� Path$ 	ErrorPage� � 	Resources   ErrorListBox �� 
TargetType �� Property �� Value �� 
TargetType ��Name	 �� CornerRadius
 �� RelativeSource �� AncestorType �� Triggers P� Property P� Value �� 
TargetName ]� 
Conditions �� Property �� Value��%I  &	       �� " ��.���  � ��$ Hidden=���  � ��
 �   ���  � ��$ 0q���  � �� �� " ��.���  � �� �� " ��.R��� $ border��$	 0��
���   �$��	0,0,0,0.2q����� 
 �� " ��$ ActualWidth�._�]� ��. $��40��.+��� $	��Top=�$	��100��$��CharacterEllipsis=�$��1q�$��12(����� *	ErrorText+�� $��0,0,20,0q�$��CharacterEllipsis=�$��12(����� *ErrorElementName+ P�  �@��
IsSelected . . ���  � ��
 �  ���� $ border�� � ��
 ������� $ border�� � ��
 �  ���� $ border�� � ��$ 	4,0,0,0.5q�]�  ��  �@J�IsMouseOver . ��  �@��
IsSelected .  /���  � ��
 �  ���� $ border�� � ��
 ������� $ border�� � ��
 �  ���� $ border�� � ��$ 	0,0,0,0.5q�.��� -   $��	ErrorGrid�� � RowDefinitions �� $��50���� $
��Auto ��� .+��� -   $��
TabControl�� �� SelectedIndex �� $ 
SelectList�.@���   TabItemStyle#��[ ���� $&  AppDataText[ErrorPage_Tab_Error]�.��]� ��. $��-3q�.+��� $	��Top=�  
PageBorder#��[ ._���  �� Orientation$ 
Horizontal=�.+��� $	��123��$��	0,0,0.5,0q��� $��0,-1,0,0q�#��[ ._��� #��[ ���� $ 	ErrorList� �� *SelectedError+ �� Mode$ TwoWay=��� #��[ ���� $' !AppDataText[ErrorPage_Tab_Prompt]�.��]� ��. $��-3q�.+��� $	��Top=�#��[ ._��� $ 
Horizontal=�.+��� $	��123��$��	0,0,0.5,0q��� $��0,-1,0,0q�#��[ ._��� #��[ ���� $ ConflictList� �� *SelectConflict+$ TwoWay=��� #��[ ���� $) #AppDataText[ErrorPage_Tab_Conflict]�.��]� ��. $��-3q�.+��� $	��Top=�#��[ ._��� $ 
Horizontal=�.+��� $	��123��$��	0,0,0.5,0q��� $��0,-1,0,0q�#��[ ._��� #��[ ���� $ 
PromptList� �� *SelectPrompt+$ TwoWay=��� #��[ ���� $% AppDataText[ErrorPage_Tab_TODO]�.��]� ��. $��-3q�.+��� $	��Top=�#��[ ._��� $ 
Horizontal=�.+��� $	��123��$��	0,0,0.5,0q��� $��0,-1,0,0q�#��[ ._��� #��[ ���� $ TODOList� �� *
SelectTODO+$ TwoWay=��� $��1��  HorizontalSplitter#��[ ]� ��. $��2��.+��� $	��Top=�#��[ ._��� $ 
Horizontal=�.+��� $	��123��$��	0,0,0.5,0q��� $��0,-1,0,0q�#��[ ._��� $
��Auto=�$
��Auto=�$��3q�.���� ���� *ErrorInformation+$ TwoWay=�