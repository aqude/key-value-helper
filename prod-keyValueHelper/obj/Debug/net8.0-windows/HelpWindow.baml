   M S B A M L   `   `   `  ����N  Jprod-keyValueHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:prod_keyValueHelperprod_keyValueHelper  5   	   $    prod_keyValueHelper.HelpWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   3local!clr-namespace:prod_keyValueHelper     5   	     � 
ResizeMode$  NoResize=�5   	    � Title$ 
HelpWindow��5	   	   $	��450��6   $	��800��6)   .��5
      � $��Center=�6   $��Center=�6(    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��Arial)�6!   $��20(�64   $
��Bold"�6B   $��Normal$�6T   $��Center=�6g   DBФорматы загрузки данных в программу6�   � 5   
   $��1��6   $��Center=�6   $��0 30 0 0q�69    � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   .+�5      �� $��0��6   $��Arial)�6(   $��20(�6;   $
��Bold"�6I   $��Normal$�6[   $��Center=�6n   $��	0 0 170 0q�6�   JSON6�   �� 5      $��1��6   $��Arial)�6(   $��20(�6;   $
��Bold"�6I   $��Normal$�6[   $��Center=�6n   $��	160 0 0 0q�6�   CSV6�   5      � 5   
   $��2��6   $��Center=�6    5      �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   .+�5      �� $��0��6   ��6$   �� *Image1JsonGetter+6K   �� 5      $��1��6   ��6$   �� *Image2CsvGetter+6I   5!      5"      5#      