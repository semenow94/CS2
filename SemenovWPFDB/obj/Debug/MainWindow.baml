   M S B A M L   `   `   `  ����G  CSemenovWPFDB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:SemenovWPFDBSemenovWPFDB  5   	       SemenovWPFDB.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:SemenovWPFDB     5   	   -   5          � Title$  
MainWindow��5   	   $	��450��5	   	   $	��800��6   .��5
      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 	WorkersDG��5      $
��Left=�6&   $	��399��6A   $��0,10,0,0q�6N   $	��Top=�6x   $	��400��6�      AutoGenerateColumns .  ��6`   ��    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      -   5        	SurColumn��,  &System.Windows.Controls.DataGridColumn   Header$ Фамилия��5   T      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6e   1  +System.Windows.Controls.DataGridBoundColumn   Binding 68   �� *	surname+6e     5      -   5        
NameColumn��$ Имя��5   R   $ * 6_    69   �� *name+6_     5      -   5        	AgeColumn��$ Возраст��5   P   $ * 6a    68   �� *age+6a     5      -   5        	DepColumn��$ Департамент��5   T   $ * 6i    68   �� *	depname+6i   5      �� 5   
   -   5         ��Name$ 	workerDel��5      $��Удалить��6$   $
��Left=�66   $��
405,50,0,0q�6Q   $	��Top=�6e   $��75��6}   6�   �� 5   
   -   5        $ 	workerAdd��5      $��Добавить��6$   $
��Left=�67   $��
405,10,0,0q�6R   $	��Top=�6f   $��75��6~   6�   �� 5   
   -	   5        $ 
workerEdit��5      $��Изменить��6%   $
��Left=�68   $��
405,30,0,0q�6S   $	��Top=�6g   $��75��6   6�   5      5      