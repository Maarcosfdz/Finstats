   M S B A M L   `   `   `  ����  Finstats    Finstats.DashboardView   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  	Dashboard��5   	   $	��400��6   $	��500��6(   .��5      � $��10q�6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��0,0,0,10q�6.   .+�5      �� -   5        $��Añadir Gasto��5      $	��150��6E   $��30��6Q   $��0,0,10,0q�6]    J� RenderTransformOrigin$ 0.427,-4.479&�6o   �� 5	      -   5        $��Añadir Ingreso��5	      $	��150��6G   $��30��6S   5
      �� 5   
   $ 
Horizontal=�6   $��	0,278,0,0q�6.   $
��Left=�6A   $	��356��6\   .+�5      �� -   5         ��Name$ txtNovaCategoria��5      $	��150��60   $��0,0,10,0q�6<   �� 5      -   5         ��Name$ cbTipoCategoria��5      $��79��60   $��0,0,10,0q�6;   $	��169��6M   .@�5      �� $��Gasto��6   
 � Tag$ 1��6/    �� 
IsSelected$
 True��67   �� 5      $��Ingreso��6   $ 0��61   5      �� 5      -   5        $��Crear categoría��5      $	��102��6N   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ MovimientosDataGrid��5         AutoGenerateColumns$ False��60   	   
IsReadOnly$
	 True��6L   $	��Top=�6^   $��0,50,0,0q�6v   $	��200��6�   
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Nombre��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *Nombre+  5      $ Cantidad��6%    67   �� *Cant+  5      $ Fecha��6%    64   �� *Data+  5      $ Categorías��6%    69   �� *Categories[0].Nombre+4  .System.Windows.Controls.DataGridTemplateColumn  5      $ Accións��6)      CellTemplate 5       �� 5!      .R�5"      �� -   5        $��Eliminar��5"   %    6Y   �� *Id+5#      5%      5'      � 5+   
   -   5         �Name$ 
popupGasto��5+      $��
MousePoint=�6$    � 	StaysOpen$ False��6;   .��5,      �� 
������� �� Padding$ 10q�6,    �� CornerRadius$ 5��69   ._�5-      �� .+�5.      �� $��Nombre:��6    �� 5/      -	   5        $ 	txtNombre��5/      �� 51      $��	Cantidad:��6    �� 52      -
   5        $ txtCantidad��52      �� 54      $��Fecha:��6    (  "System.Windows.Controls.DatePicker  55      -   5          Name$ 	dateFecha��55   !   �� 57      $��Categoría:��6    �� 58      -   5        $ cbCategoria��58       �� DisplayMemberPath$ Nombre��64   �� 5<      $ 
Horizontal=�6!   $��Right=�6:   $��0,10,0,0q�6V   .+�5=      �� -   5        $��Guardar Gasto��5=   !   $��5q�6T   �� 5>      -   5        $��Guardar Ingreso��5>   !   $��5q�6X   �� 5?      -   5        $��Cerrar��5?   !   $��5q�6L   5@      5A      5B      5C      �� 5D   
   -   5        $��Eliminar categoría��5D      $��390,278,0,0q�6N   5F      5G      