   M S B A M L   `   `   `  ����O  KWpfPatientManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:WpfPatientManagement.ControlsWpfPatientManagement.Controls  5      Q-clr-namespace:WpfPatientManagement.ConvertersWpfPatientManagement.Converters  5      ,    &WpfPatientManagement.Controls.TitleBar   5      W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =local+clr-namespace:WpfPatientManagement.Controls     5      [ WFontAwesome6.Svg.Net, Version=2.5.1.0, Culture=neutral, PublicKeyToken=150287d219411f042fa6(http://schemas.fontawesome.com/icons/svg  5      >
converters-clr-namespace:WpfPatientManagement.Converters  5      -   5          >�Name$
  root��5       � 	Resources 5      @   :WpfPatientManagement.Converters.WindowStateMarginConverter   WindowStateMarginConverter>   8WpfPatientManagement.Converters.WindowStateIconConverter  WindowStateIconConverter �� 
TargetType �� Property �� Value'  !System.Windows.Shell.WindowChrome!  FontAwesome6.Svg.SvgAwesome  	ColorGray��%�  &	        &	      '�� &     '  D    7    5   
   60     5   
   6.   �� 5   
   " ��6   .�5      ��  � ��$ 25��6&   �� 5       � ��$ 20��6'   �� 5       � ��
 ���� 6+   �� 5       � ��
 ���� 6,   �� 5       � ��$ Right=�6/   �� 5        �@ IsHitTestVisibleInChrome$
 True��6F   5      �� 5   
   "  6   .�5      ��  �@ PrimaryColor8   6-   5      5      .��5      ]�   	ColorNavy#��[ 6   $
��True��5      .+�5    
   �� -   5         ��Name$ btnExit��5       ��5!      �� *
WinState+ �� ElementName$
 root�� �� 	Converter# [   �� ConverterParameter$
 Exit��.��5%        	   Icon$	 Solid_Xmark=�6   5&      �� 5'   
   -   5        $ btnMaximize��5'      ��5(      �� *
WinState+$
 root��# [  .��5+        $��13��5.      $��13��6(   	 5+      �� *
WinState+$
 root��# [ 5.   (   5/      �� 50   
   -   5        $ btnMinimize��50      ��51      �� *
WinState+$
 root��# [  .��54        $	 Solid_Minus=�6   55      �� 57   
   -   5        
������ 
   IsHitTestVisibleInChrome$
 False��59      5:      5;      