   M S B A M L   `   `   `  ����A  =OrozGP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:OrozGP.InterfazGrafica.Catalogos OrozGP.InterfazGrafica.Catalogos  5      6    0OrozGP.InterfazGrafica.Catalogos.PanelMateriales   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      @local.clr-namespace:OrozGP.InterfazGrafica.Catalogos     5      .��5	      � .+�5
   
   �� -   5          ��Name$  label��5
      $��¿Algo en especial?��6   $��140,10,140,0q�6<   $	��Top=�6R   $��28(�6j   $��Center=�6x   �� 5   
   -   5         ��Name$ campoBusqueda��5      $��32��6)   $��140,60,140,0q�65    �� TextWrapping$
 Wrap=�6K   $�� ��6_   $	��Top=�6g   $��20(�6   $��0q�6�   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ tabla��5      $��10,138,10,88q�6"      AutoGenerateColumns .     
IsReadOnly . !   EnableColumnVirtualization .    EnableRowVirtualization .    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Nombre��6h   
   FontSize$
 18Q�6x      Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6�   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   ��  �� Path$ Nombre�   ClipboardContentBinding 6E   Z� 6�     5      $	 Clave��6g   $
 Auto 6v   $
 18Q�6�    6%   �� $ Clave� 6D   Z� 6�     5      $	 	Proveedor��6k   $
 18Q�6~   $	 100 6�    6%   �� $ 	Proveedor� 6H   Z� 6�     5      $
	 Alto��6f   $
 18Q�6t   $
 Auto 6�    6%   �� $
 Alto� 6C   Z� 6�     5      $	 Ancho��6g   $
 Auto 6v   $
 18Q�6�    6%   �� $ Ancho� 6D   Z� 6�     5      $	 Grosor��6h   $
 18Q�6x   $
 Auto 6�    6%   �� $ Grosor� 6E   Z� 6�     5      $	 Precio��6h   $
 Auto 6x   $
 18Q�6�    6%   �� $ Precio� 6E   Z� 6�     5      $		 Iva��6l   $
 18Q�6y   $
 Auto 6�    6%   �� $ 
IvaEnTexto� 6I   Z� 6�   5      �� 5   
   -   5         ��Name$ botonEditar��5      $��Editar��6&   $
��Left=�67   $��	10,0,0,10q�6R   $��90��6e      botonAccion#���   6p   $��35��6�   $��Bottom=�6�   6�   �� 5   
   -   5        $ botonEliminar��5      $��Eliminar��6(   $
��Left=�6;   $��
114,0,0,10q�6V   $��90��6j     
botonError#���  6u   $��35��6�   $��Bottom=�6�   6�   �� 5   
   -   5        $ 
botonNuevo��5      $��Nuevo��6%   $��Right=�65   $��	0,0,10,10q�6Q   $��90��6d     botonOk#���  6o   $��35��6�   $��Bottom=�6�   6�   �� 5   
   -   5         ��Name$ botonRegresar��5      $
��Left=�6'   $��30��6B   $��	10,98,0,0q�6N   $	��Top=�6a   $��30��6y   $:��4/OrozGP;component/Recursos/Imagenes/chevron-left.png��6�   6�   �� 5   
   -   5        $  etiquetaCategoria��5      $��Nombre categoría��6+   $
��Left=�6F   $��	40,91,0,0q�6a   $	��Top=�6t   $��24(�6�   5       � 	Resources 5        �� MergedDictionaries �� Source�� 5!   
    5"      �� 5#      $5 //OrozGP;component/Recursos/Estilos/Botones.xaml?�6%   %    5%      5'      