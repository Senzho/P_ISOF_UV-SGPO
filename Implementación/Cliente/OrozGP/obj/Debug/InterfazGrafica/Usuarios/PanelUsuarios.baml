   M S B A M L   `   `   `  ����A  =OrozGP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:OrozGP.InterfazGrafica.UsuariosOrozGP.InterfazGrafica.Usuarios  5      3    -OrozGP.InterfazGrafica.Usuarios.PanelUsuarios   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ?local-clr-namespace:OrozGP.InterfazGrafica.Usuarios     5      .��5	      � .+�5
   
   �� -   5          ��Name$  label��5
      $��¿Alguien en especial?��6   $��140,10,140,0q�6?   $	��Top=�6U   $��28(�6m   $��Center=�6{   �� 5   
   -   5         ��Name$ campoBusqueda��5      $��32��6)   $��140,60,140,0q�65    �� TextWrapping$
 Wrap=�6K   $�� ��6_   $	��Top=�6g   $��20(�6   $��0q�6�   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ tabla��5      $��10,109,10,88q�6"      AutoGenerateColumns .     
IsReadOnly . !   EnableColumnVirtualization .    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Nombre��6h   	   FontSize$	 18Q�6x   
   Width5  /System.Windows.Controls.DataGridLengthConverter$	
 200 6�   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   ��  �� Path$ Nombre�   ClipboardContentBinding 6E   Z� 6�     5      $ Correo��6h   $	
 200 6x   $	 18Q�6�    6%   �� $ Correo� 6E   Z� 6�     5      $ Puesto��6h   $	 18Q�6x   $	
 200 6�    6%   �� $ Puesto� 6E   Z� 6�   5      �� 5   
   -   5         ��Name$ botonEditar��5      $��Editar��6&   $
��Left=�67   $��	10,0,0,10q�6R   $��90��6e      botonAccion#���   6p   $��35��6�   $��Bottom=�6�   6�   �� 5   
   -   5        $ botonEliminar��5      $��Eliminar��6(   $
��Left=�6;   $��
114,0,0,10q�6V   $��90��6j     
botonError#���  6u   $��35��6�   $��Bottom=�6�   6�   �� 5   
   -   5        $ botonCredenciales��5      $��Generar credenciales��6,   $
��Left=�6K   $��
218,0,0,10q�6f   $	��210��6z     
botonExtra#���  6�   $��35��6�   $��Bottom=�6�   6�   �� 5   
   -   5        $ 
botonNuevo��5      $��Nuevo��6%   $��Right=�65   $��	0,0,10,10q�6Q   $��90��6d     botonOk#���  6o   $��35��6�   $��Bottom=�6�   6�   5       � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $5 //OrozGP;component/Recursos/Estilos/Botones.xaml?�6%   %    5      5!      