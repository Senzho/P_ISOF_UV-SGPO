   M S B A M L   `   `   `  ����A  =OrozGP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:OrozGP.InterfazGrafica.UsuariosOrozGP.InterfazGrafica.Usuarios  5      2    ,OrozGP.InterfazGrafica.Usuarios.PanelUsuario   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ?local-clr-namespace:OrozGP.InterfazGrafica.Usuarios     5        � 	Resources  5	       �� MergedDictionaries �� Source�� 5
   
    5      �� 5      $5 //OrozGP;component/Recursos/Estilos/Botones.xaml?�6%   %    5      .��5      � .+�5   
   �� -   5         ��Name$ botonRegresar��5      $
��Left=�6'   $��30��6B   $��	10,10,0,0q�6N   $	��Top=�6a   $��30��6y   $:��4/OrozGP;component/Recursos/Imagenes/chevron-left.png��6�   6�   �� 5   
   -   5         ��Name$ label��5      $��Usuario��6   $
��Left=�61   $��40,3,0,0q�6L   $	��Top=�6^   $��24(�6v   �� 5   
   -   5        $ etiquetaNombre��5      $��Nombre:��6(   $
��Left=�6:   $��	10,85,0,0q�6U   $	��Top=�6h   $��20(�6�   �� 5   
   -   5         ��Name$ campoNombre��5      $��30��6'   $��107,90,10,0q�63    �� TextWrapping$
 Wrap=�6H   $�� ��6\   $	��Top=�6d   $��20(�6|   �� 5   
   -   5        $ etiquetaCorreo��5      $��Correo:��6(   $
��Left=�6:   $��
10,120,0,0q�6U   $	��Top=�6i   $��20(�6�   �� 5   
   -   5        $ campoCorreo��5      $��30��6'   $��107,125,10,0q�63   $
 Wrap=�6I   $�� ��6]   $	��Top=�6e   $��20(�6}   �� 5   
   -   5        $ etiquetaPuesto��5      $��Puesto:��6(   $
��Left=�6:   $��
10,155,0,0q�6U   $	��Top=�6i   $��20(�6�   �� 5   
   -   5        $ campoPuesto��5      $��30��6'   $��107,160,10,0q�63   $
 Wrap=�6I   $�� ��6]   $	��Top=�6e   $��20(�6}   �� 5   
   -	   5         ��Name$ botonEliminar��5      $��Cancelar��6(   $
��Left=�6;   $��	10,0,0,10q�6V   $��90��6i      
botonError#���   6t   $��35��6�   $��Bottom=�6�   6�   �� 5   
   -
   5        $ botonGuardar��5      $��Guardar��6'   $��Right=�69   $��	0,0,10,10q�6U   $��90��6h     botonOk#���  6s   $��35��6�   $��Bottom=�6�   {�.  6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ tablaPermisos��5      $	��186��6*   $��107,195,10,0q�67   $	��Top=�6M   	   AutoGenerateColumns	 .  
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Ámbito��6h      FontSize$ 18Q�6x   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   ��  �� Path$ Ambito�   ClipboardContentBinding 6E   Z� 6x   4  .System.Windows.Controls.DataGridCheckBoxColumn  5      $ 	Consultar��6o    6)   �� $ 	Consultar� 6L   Z� 6o     5      $ Crear��6k    6)   �� $ Crear� 6H   Z� 6k     5       $ 	Modificar��6o    6)   �� $ 	Modificar� 6L   Z� 6o     5!      $ Eliminar��6n    6)   �� $ Eliminar� 6K   Z� 6n   5#      �� 5$   
   -   5        $ etiquetaPermisos��5$      $��	Permisos:��6*   $
��Left=�6>   $��
10,189,0,0q�6Y   $	��Top=�6m   $��20(�6�   5&      5'      