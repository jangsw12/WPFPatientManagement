   M S B A M L   `   `   `  ����A  =WpfLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfLib.ControlsWpfLib.Controls  5      5clr-namespace:WpfLib.ConvertersWpfLib.Converters  5      (    "WpfLib.Controls.PasswordBoxControl   5      W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:WpfLib.Controls     5      6
convertersclr-namespace:WpfLib.Converters     5      -   5          >�Name$
  root��5
       � 	Resources 5      :   4WpfLib.Converters.ValidatingBorderThicknessConverter &  "ValidatingBorderThicknessConverter6   0WpfLib.Converters.ValidatingBorderBrushConverter " ValidatingBorderBrushConverter  BaseControl �� 
TargetType �� Property �� Value �� ElementName �� BasedOn �� Triggers �� Binding	 �� Value
 �� UpdateSourceTrigger `� 	Converter �� Path��%i  &	        &	      &	 &     '�� �     7  '�� �    'G� :    7  7   7    5   
   68     5   
   64   �� 5   
   " �6$   .�5      ��  � �� 61   �� *
FontSize+$
 root���� 5       � �� 63   �� *
FontFamily+$
 root��5      �� 5   
   " ��6   8   .�5      ��  � �� 6%   �� *WaterMarkText+$
 root���� 5       � �� 6+   �� *WaterMarkTextColor+$
 root���� 5       �@��Padding$ 5 0 0 0q�6(   �� 5       � ��$
 Left=�64   �� 5       � ��$ Center=�62   �� 5       � y�$ 	Collapsed=�6+    5      �� 5       6   �� *Text+$	 txt��	  6H   .a�5      ��  � y�$ Visible=�63   5      5       �� 5"   
   " ��6   .�5#      ��  � �� 6%   �� *
Password+$
 root��$
 PropertyChanged=��� 5$       � y�$ 	Collapsed=�6+   5%      �� 5'   
   " G�6   8   .�5(      ��  � ��
 ���� 6+   �� 5)       � ��$ Center=�69   �� 5*       � �� 5+      `� 5,      8  .1�5-      �� $ 
Validating�6"   $
 root��64   �� 5.      $ BorderThickness�6"   $
 root��69   5/      51      �� 52       � �� 53      `� 54      8  .1�55      �� $ 
Validating�6"   $
 root��64   �� 56      $ BorderBrush�6"   $
 root��65   57      59      5:      5;      .��5=      � .+�5>   
   �� �� 5?   
   -   5         ��Name$	 txt��5?      G� 5@   
   -   5         G�Name$	 pwd��5@      5A      5B      