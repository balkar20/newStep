   M S B A M L   `   `   `  ����H  DCommandSamle1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:CommandSamle1CommandSamle1  5   	       CommandSamle1.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:CommandSamle1     5   	     � Title$  
MainWindow��5   	   $	��350��6   $	��525��6)    J� CommandBindings 5	      )  #System.Windows.Input.CommandBinding  5
   
   -   5           Command$ local:WindowCommands.Exit��5
      6=   .��5      � .+�5   
   o� $	��Top=�6   $��25��6'   .@�5      m� $��
Выход��6    m� Command$ local:WindowCommands.Exit��6&   5      �� 5   
   -   5         ��Name$ Button1��5      $��80��6"   $��30��6-   $��
Выход��69   $��local:WindowCommands.Exit��5      5      5      