   M S B A M L   `   `   `  ����H  DScrabble_Game, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Scrabble_GameScrabble_Game  5   	       Scrabble_Game.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:Scrabble_Game     5   	     � Title$  
MainWindow��5   	   $	��676��6   $	��638��6)   .��5	      � ��5
   
   �� 5       �� ImageSource$ Images/background.jpg��6   .+�5   
   �� -   5         ��Name$ startLbl��5      $��
Start Game��6"   $
��Left=�67   $��195,305,0,0q�6R   $	��Top=�6g   $��60(�6   $$��Tw Cen MT Condensed Extra Bold)�6�   ���	#03FFFFFF J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         Opacity$	 0.5Q�6#      ShadowDepth$ 4Q�61   5      �� 5   
   -   5        $ aboutLbl��5      $��About Scrabble��6"   $
��Left=�6;   $��228,431,0,0q�6V   $	��Top=�6k   $��24(�6�   $��Sitka Small)�6�   $	��194��6�    5        5      $ 3Q�6#   $	 0.5Q�63   5      �� 5   
   -   5        $ exitLbl��5      $
��Exit��6!   $
��Left=�60   $��291,507,0,0q�6K   $	��Top=�6`   $��24(�6x   $��Sitka Small)�6�    5        5      $ 3Q�6#   $	 0.5Q�63   5      �� 5   
   -   5         ��Name$ 
focusTile1��5      $
��Left=�6(   $��18��6C   $��166,333,0,0q�6O   
���   �$	��Top=�6s   $��18��6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   $y�Hidden=�6�    5        5      $ 3Q�6#   $	 0.5Q�63   z�5       V� 5!      .~�5"      �� �� 5#      �� 5$       �� Angle$ -25.385Q�6&   T� 5%      5&      ��5(      �� 5)      $ Images/tile.jpg��6   5+      �� 5,   
   -   5        $ 
focusTile2��5,      $
��Left=�6(   $��18��6C   $��201,438,0,0q�6O   
���   �$	��Top=�6s   $��18��6�   $ 0.5,0.5&�6�   $y�Hidden=�6�    5-        5.      $ 3Q�6#   $	 0.5Q�63   z�50      V� 51      .~�52      �� �� 53      �� 54      $ -28.975Q�6&   T� 55      56      ��58      �� 59      $ Images/tile.jpg��6   5;      �� 5<   
   -   5        $ 
focusTile3��5<      $
��Left=�6(   $��18��6C   $��265,515,0,0q�6O   
���   �$	��Top=�6s   $��18��6�   $ 0.5,0.5&�6�   $y�Hidden=�6�    5=        5>      $ 3Q�6#   $	 0.5Q�63   z�5@      V� 5A      .~�5B      �� �� 5C      �� 5D      $ -33.565Q�6&   T� 5E      5F      ��5H      �� 5I      $ Images/tile.jpg��6   5K      �� 5L   
   -   5        	 ��Name$	 playerSelectComboBox��5L      
 �� SelectedValuePath$
 Content��61   $
��Left=�6M   $��170,320,0,0q�6h   $	��Top=�6}    �� SelectedIndex$ 0��6�   $	��302��6�   $��24(�6�   $y�Hidden=�6�   $��46��6  .@�5M      �� $��Select Number of Players��6   6@   �� 5N      $��1 Player��6   60   �� 5O      $��	2 Players��6   61   �� 5P      $��	3 Players��6   61   �� 5Q      $��	4 Players��6   61   5R      5S      5T      