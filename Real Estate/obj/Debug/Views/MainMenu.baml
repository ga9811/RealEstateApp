   M S B A M L   `   `   `  ����F  BReal Estate, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Real_EstateReal_Estate  5   	       Real_Estate.MainMenu   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Real_Estate     5   	     � Title$  MainMenu��5   	   $	��450��6   $	��700��6'   .��5	      � .+�5
   
   �� $
��Left=�6   $	��434��6,   $��Center=�69   $	��207��6T   ���	#FF18B0A4.+�5      �� -   5        $��Property��5      $��49��6(    �� Left$ 44��64   
 �� Top$ 97��6E   $	��122��6U   $
��Bold"�6a   ���	#FFEE0EE46�   �� 5      -   5        $��Client��5      $��49��6&   $ 44��62   $	 171��6C   $	��122��6T   $
��Bold"�6`   $��Center=�6r   $	��Top=�6�   ���	#FFEE0EE46�   �� 5      -   5        $
��User��5      $��49��6$   $ 44��60   $	 247��6A   $	��122��6R   $
��Bold"�6^   $��Center=�6p   $	��Top=�6�   ���	#FFEE0EE46�   �� 5      -   5        $
��Exit��5      $��49��6$   $ 44��60   $	 323��6A   $	��122��6R   $
��Bold"�6^   $��Center=�6p   $	��Top=�6�   ���	#FFEE0EE46�   5      �� 5   
   $��Appointment List��6   $
��Left=�6+   $��29��6F   $��
252,27,0,0q�6R   $	��Top=�6f   $	��109��6~    J� RenderTransformOrigin$ 0.456,-0.181&�6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ appointmentdataGrid��5      $
��Left=�60   $	��125��6K   $��
254,61,0,0q�6X   $	��Top=�6l   $	��410��6�      AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Agent Name��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *
agent_name+  5      $ Client Name��6%    6:   �� *client_name+  5      $ Schedule Type��6%    6<   �� *schedule_type+  5      $ Schedule Time��6%    6<   �� *schedule_time+5      �� 5   
   $��
Track List��6   $
��Left=�6%   $��29��6@   $��252,209,0,0q�6L   $	��Top=�6a   $	��109��6y   $ 0.456,-0.181&�6�     5   
   -   5        $ trackDataGrid��5      $
��Left=�6*   $	��119��6E   $��254,244,0,0q�6R   $	��Top=�6g   $	��410��6    .   5   
     5      $ Property ID��6!    66   �� *id+  5      $ Address��6!    62   �� *	address+  5      $ Inspec Status��6!    68   �� *inspection_status+  5      $
 Date��6%    63   �� *inspection_date+  5       $ Repair Status��6%    6<   �� *repair_status+  5!      $
 Date��6%    63   �� *repair_date+5#      5$      5%      