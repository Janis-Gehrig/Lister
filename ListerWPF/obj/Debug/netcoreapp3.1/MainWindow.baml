   M S B A M L   `   `   `  ����D  @ListerWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:ListerWPF	ListerWPF  5   	       ListerWPF.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:ListerWPF     5   	     � Title$  Lister��5   	   $	��450��6   $	��800��6%    � WindowStartupLocation$ CenterScreen=�5	   	    � 	Resources 5         sync 
 nosync��%g   &	        &	 (     �� 5   
   $��Icons/sync.png��6   �� 5   
   $��Icons/no_sync.png��6   5      .��5      � ��5   
   �� 5       �� Color$ #404751��6    � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��20 �6    � ColumnDefinitions 5   
   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $	��150 �6   �� 5      $��50 �6   �� 5       $��50 �6   �� 5!      $��50 �6   �� 5"      $��50 �6   �� 5#      $��50 �6   .+�5)   
   �� -   5         ��Name$ btn_openSource��5)      $��40��6)   $��40��65   $��0��6@   $��0��6M   $��1q�6]   ��5*      �� 5+       �� ImageSource$ Icons/open_source.png��6    j� Stretch$
 Fill=�6A   5-      �� 5/   
   -   5        $ btn_save��5/      $��40��6$   $��40��60   $��0��6;   $��1��6H   $��1q�6X   ��50      �� 51      $ Icons/save.png��6   $
 Fill=�6:   53      �� 55   
   -   5        $ btn_transpose��55      $��40��6)   $��40��65   $��0��6@   $��2��6M   $��1q�6]   ��56      �� 57      $ Icons/transpose.png��6   $
 Fill=�6?   59      �� 5;   
   -   5        	 ��Name$	 search��5;   #   $��5,5,0,5q�6   $��40��63   $	��140��6?   $��0��6K   $��4��6X   .��6i   5=      �� 5>   
   -   5        
 ��Name$
 cb_searchSelection��5>   $   $��0,5,5,5q�6   $��40��6@   $��40��6L   $��0��6W   $��5��6d   .@�5?      �� $��ComboBoxItem��6   �� 5@      $��ComboBoxItem��6   5B      �� 5D   
   -   5        $��btn_autoSync��5D   #   $��9��67   $��40��6G   $��40��6S   .��5E      C�  C� ResourceKey$
 sync��6   5F      � 5H   
   $��0��6   $��7��6    5I      �� 5J      $��25 �6    �� 5K      $��25 �6    .+�5M      �� -   5        $ btn_incSize��5M   &   $��5,5,5,0q�6   $��+��6;   �� 5N      -   5        $ btn_decSize��5N   &   $��5,0,5,5q�6   $��-��6;   $��1��6G   5O      &   System.Windows.Controls.DataGrid  5P   
   -	   5          Name$ 
myDataGrid��5P      $��10��6'   $��10,10,-190,-354q�6<   $��1��6U   $ �� IsSynchronizedWithCurrentItem$ FalseY�6b   5Q      5S      