   M S B A M L   `   `   `  ����A  =WebBot, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WebBotWebBot  5   	       WebBot.Login   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:WebBot     5   	   -   5        $��Loginwindow��5   	     � Title$  Login��5	   	   $	��120��6   $	��300��6$    � 
ResizeMode$ NoResize=�60    � WindowStyle$
 None=�6F   ���	#FFD4D4D4$��1,0,1,1q�6q    � ShowInTaskbar .  .��5
      � $	��118��6   $��Bottom=�6   .+�5   
   �� -   5         ��Name$ button_login��5      $��login��6'   $��	0,0,10,10q�67   $��20��6J   $��Bottom=�6V   $��Right=�6q   $��75��6�   6�   �� 5   
   -   5         ��Name$ label_username��5      $��Benutzername:��6(   $
��Left=�6@   $	��Top=�6[   $��	10,10,0,0q�6s   �� 5   
   -   5         ��Name$ textBox_username��5      $
��Left=�6,   $��22��6G    �� TextWrapping$
 Wrap=�6S   $	��Top=�6g   $	��120��6   $��	10,36,0,0q�6�   $��Center=�6�   $��Syrokx��6�   G� 5   
   -   5         G�Name$ passwordBox��5      $
��Left=�6+   $��
10,86,0,10q�6F   $	��120��6Z   $��Center=�6f   	 G� Password$	 
1234567890��6�   �� 5   
   -   5        $ label_password��5      $��	Passwort:��6(   $
��Left=�6<   $��	10,0,0,32q�6W   $��26��6j   $��Bottom=�6v   �� 5   
   -   5        $ label_world��5      $��Welt:��6%   $��Right=�65   $	��Top=�6Q   $��	0,10,93,0q�6i   �� 5   
   -   5        
 ��Name$
 comboBox��5      $��Right=�6%   $	��Top=�6A   $	��120��6Y   $��	0,36,10,0q�6e    �� SelectedIndex$ 11��6x   .@�5      �� -	   5        $ label1��5      $��Alpha��6$   �� 5      -
   5        $ label2��5      $
��Beta��6$   �� 5      -   5        $ label3��5      $��Gamma��6$   �� 5      -   5        $ label4��5      $��Delta��6$   �� 5      -   5        $ label5��5      $��Epsilon��6$   �� 5      -   5        $ label6��5      $��Pi��6$   �� 5      -   5        $ label7��5      $	��Rho��6$   �� 5      -   5        $ label8��5      $��Sigma��6$   �� 5      -   5        $ label9��5      $��Boreas��6$   �� 5      -   5        $ label10��5      $��Charon��6%   �� 5      -   5        $ label11��5      $��Demeter��6%   �� 5      -   5        $ label12��5      $��Dionysos��6%   5      �� 5   
   -   5        $ button��5      $��	abbrechen��6!   $
��Left=�65   $	��Top=�6P   $��70��6h   $��
135,88,0,0q�6s   6�   �� 5    
   -   5        $ label_error��5       $�� ��6%   $
��Left=�60   $	��Top=�6K   $��
130,63,0,0q�6c   $	��168��6w   $��Center=�6�   $��Center=�6�   5"      5#      