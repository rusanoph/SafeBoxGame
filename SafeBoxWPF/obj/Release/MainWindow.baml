   M S B A M L   `   `   `  ���� E  ASafeBoxWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:SafeBoxWPF
SafeBoxWPF      SafeBoxWPF.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     *localclr-namespace:SafeBoxWPF       � WindowStartupLocation$  CenterScreen=� � Title$ Safe Box Game��$	��600��$	��800��$	��600��$	��600��$��Segoi UI Light)�$��28(�.���  � RowDefinitions �� $
��auto ��� $��* ��� $��40 � � ColumnDefinitions �� $��40 ��� $��* ��� $
��1.5* ��� $��* ��� $��40 �.+��� -   $
��Exit��$��0��$��1��$��10 15q��� -    ��Name$ 	StepsText��$��0��$��2��$��Steps: ��$��20q� �� TextAlignment$ Center=��� -   $
��Menu��$��0��$��3��$��10 15q�(� $��1��$��1��$��3��$��20q�.���� -    ��Name$ 
GameCanvas�����#bababa$	��400��$	��400��}�. � -    �Name$ MainMenu�����#3d3d3d$��3��$��5��$y�Visible=�.+��� $��Center=�$��Center=�.+��� -   $
��Play��
�������$��20q�$��5q�$	��200���� -    ��Name$ DifficultButton��$��Difficult: 2x2��
�������$��20q�$��5q�$	��200���� -   $
��Exit��
�������$��20q�$��5q�$	��200��� -	   $ GameOverMenu�����	#CC000000$��3��$��5��$y�Hidden=�.+��� $��Center=�$��Center=�.+��� $��You Win��$��48(�$ Center=�
��������� -
   $ FinalStepsText��$��In _ steps ��$��36(�$ Center=�
��������� -   $��
Play Again��
�������$��0 20 0 0q�$��5q�