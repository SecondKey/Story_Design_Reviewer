   M S B A M L   `   `   `  ����c  _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  5      P LStory_Design_Reviewer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Story_Design_ReviewerStory_Design_Reviewer 5      *   $Story_Design_Reviewer.ErrorListPanel   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      b ^GalaSoft.MvvmLight.Platform, Version=5.4.1.0, Culture=neutral, PublicKeyToken=5f873c45e98af8a1+mvvm http://www.galasoft.ch/mvvmlight  5      XiPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity  5      /local#clr-namespace:Story_Design_Reviewer  5      .command http://www.galasoft.ch/mvvmlight  5	      -   5        $
��main��5        � DataContext  5      ��    Locator �� Source# [   �� Path$ 	ErrorPage� � 	Resources 5        ErrorListBox �� 
TargetType �� Property �� Value �� 
TargetType ��Name	 �� CornerRadius
 �� RelativeSource �� AncestorType �� Triggers P� Property P� Value �� 
TargetName ]� 
Conditions �� Property �� Value��%d  &	       �� 5   
   " ��6%   .�5      ��  � ��$ Hidden=�6K   �� 5       � ��
 �   �6,   �� 5       � ��$ 0q�60   �� 5       � �� 5      �� 5      " ��6   .�5      ��  � �� 5      �� 5   "   " ��62   .R�5   &   �� $ border��5   -   $	 0��6=   
���   �$��	0,0,0,0.2q�5   )   ��5   -   �� 
 �� " ��$ ActualWidth�._�5   *   ]� ��. $��40��6K   .+�5   .   �� $	��Top=�68   $	��100��6M   $��CharacterEllipsis=�6\   $��1q�6~   $��12(�6�   ��6�   �� *	ErrorText+�� 5   .   $��0,0,20,0q�68   $��CharacterEllipsis=�6J   $��12(�6k   ��6y   �� *ErrorElementName+5   +   5    '    5!   &   P� 5"   *    �@��
IsSelected . . �5#   .   ��  � ��
 �  ��6K   �� 5$   .   $ border��65    � ��
 �����6_   �� 5%   .   $ border��65    � ��
 �  ��6`   �� 5&   .   $ border��65    � ��$ 	4,0,0,0.5q�6d   5'   +   ]� 5(   *    5)   .   �� 5*   2    �@J�IsMouseOver . 6S   �� 5+   2    �@��
IsSelected .  6R   /�5-   .   �� 5.   2    � ��
 �  ��6O   �� 5/   2   $ border��69    � ��
 �����6c   �� 50   2   $ border��69    � ��
 �  ��6d   �� 51   2   $ border��69    � ��$ 	0,0,0,0.5q�6h   53   +   55   #   57      58      5:      5;      5<      .��5>      � -   5        $��	ErrorGrid��5>       � RowDefinitions 5?   
   �� 5@      $��50��6   6-   �� 5A      $
��Auto �6   6,   �� 5B      6   .+�5F   
   �� -   5        $��
TabControl��5F       �� SelectedIndex 6'   �� $ 
SelectList�.@�5G      ��   TabItemStyle#��[ 6P   ��6   �� $&  AppDataText[ErrorPage_Tab_Error]�.��5H      ]� ��. $��-3q�61   .+�5I      �� $	��Top=�6     
PageBorder#��[ 62   ._�5J      ��  �� Orientation$ 
Horizontal=�6%   .+�5K      �� $	��123��6&   $��	0,0,0.5,0q�64   5L      5M      �� 5N      $��0,-1,0,0q�6   #��[ 6/   ._�5O      �� #��[ 6"   ��5P   "   �� $ 	ErrorList� 5Q   "   �� *SelectedError+ �� Mode$ TwoWay=�5R      5S      5T      5U      �� 5V      #��[ 6P   ��6   �� $' !AppDataText[ErrorPage_Tab_Prompt]�.��5W      ]� ��. $��-3q�61   .+�5X      �� $	��Top=�6   #��[ 62   ._�5Y      �� $ 
Horizontal=�6%   .+�5Z      �� $	��123��6&   $��	0,0,0.5,0q�64   5\      5]      �� 5^      $��0,-1,0,0q�6   #��[ 6/   ._�5_      �� #��[ 6"   ��5`   "   �� $ ConflictList� 5a   "   �� *SelectConflict+$ TwoWay=�5b      5c      5d      5e      �� 5f      #��[ 6R   ��6   �� $) #AppDataText[ErrorPage_Tab_Conflict]�.��5g      ]� ��. $��-3q�61   .+�5h      �� $	��Top=�6   #��[ 62   ._�5i      �� $ 
Horizontal=�6%   .+�5j      �� $	��123��6&   $��	0,0,0.5,0q�64   5k      5l      �� 5m      $��0,-1,0,0q�6   #��[ 6/   ._�5n      �� #��[ 6"   ��5o   "   �� $ 
PromptList� 5p   "   �� *SelectPrompt+$ TwoWay=�5q      5r      5s      5t      �� 5u      #��[ 6N   ��6   �� $% AppDataText[ErrorPage_Tab_TODO]�.��5v      ]� ��. $��-3q�61   .+�5w      �� $	��Top=�6   #��[ 62   ._�5x      �� $ 
Horizontal=�6%   .+�5y      �� $	��123��6&   $��	0,0,0.5,0q�64   5z      5{      �� 5|      $��0,-1,0,0q�6   #��[ 6/   ._�5}      �� #��[ 6"   ��5~   "   �� $ TODOList� 5   "   �� *
SelectTODO+$ TwoWay=�5�      5�      5�      5�      5�      �� 5�   
   $��1��6     HorizontalSplitter#��[ 6$   ]� 5�   
   ��. $��2��6)   .+�5�      �� $	��Top=�6   #��[ 6*   ._�5�      �� $ 
Horizontal=�6   .+�5�      �� $	��123��6   $��	0,0,0.5,0q�6,   5�      5�      �� 5�      $��0,-1,0,0q�6   #��[ 6'   ._�5�      �� $
��Auto=�6   $
��Auto=�6B   $��3q�6h   .��5�      �� ��6    �� *ErrorInformation+$ TwoWay=�5�      5�      5�      5�      5�      