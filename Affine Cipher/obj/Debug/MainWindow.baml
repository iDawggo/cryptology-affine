   M S B A M L   `   `   `  ????H  DAffine Cipher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Affine_CipherAffine_Cipher  5   	       Affine_Cipher.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:Affine_Cipher     5   	     ? Title$  Affine Cipher??5   	   $	??400??6   $	??600??6,   .??5	      ? .+?5
   
   ?? -   5         ??Name$
 txtA??5
      $
??Left=?6    $??23??6;   $??	40,30,0,0q?6G    ?? TextWrapping$
 Wrap=?6Z   $?? ??6n   $	??Top=?6v   $	??120??6?   ?? 5   
   $
??Left=?6   $??	20,33,0,0q?6/   $
??Wrap=?6B   $??a:??6V   $	??Top=?6`   ?? 5   
   -   5        $
 txtB??5      $
??Left=?6    $??23??6;   $??	40,60,0,0q?6G   $
 Wrap=?6Z   $?? ??6n   $	??Top=?6v   $	??120??6?   ?? 5   
   $
??Left=?6   $??	20,63,0,0q?6/   $
??Wrap=?6B   $??b:??6V   $	??Top=?6`   ?? 5   
   $
??Left=?6   $??
40,100,0,0q?6/   $
??Wrap=?6C   $??
Input Text??6W   $	??Top=?6i   ?? 5   
   $
??Left=?6   $	??200??62   $??
40,120,0,0q?6?   $	??Top=?6S   $	??227??6k   .??5      ?? -   5        $ 
scrllInput??5      $
 Wrap=?6*   $?? ??6>   5      ?? 5   
   $
??Left=?6   $??300,100,0,0q?6/   $
??Wrap=?6D   $??Output Text??6X   $	??Top=?6k   ?? 5   
   $
??Left=?6   $	??200??62   $??300,120,0,0q?6?   $	??Top=?6T   $	??227??6l   .??5      ?? -   5         ??Name$ scrllOutput??5      $
??Wrap=?6-   $?? ??6A   5      ?? 5   
   -   5         ??Name$ 
txtEncrypt??5      $??Encrypt Input Text??6%   $
??Left=?6B   $??
213,30,0,0q?6]   $	??Top=?6q   $	??120??6?   $??23??6?   6?   ?? 5   
   -   5        $ 
txtDecrypt??5      $??Decrypt Input Text??6%   $
??Left=?6B   $??
213,60,0,0q?6]   $	??Top=?6q   $	??120??6?   $??23??6?   6?   ?? 5   
   -   5        $ errors??5      $
??Left=?6$   $??
377,30,0,0q?6?   $
??Wrap=?6S   $	??Top=?6g   $??53??6   $	??150??6?   ?? 5   
   -   5        $ openText??5      $??Open Text File??6#   $
??Left=?6<   $??
40,325,0,0q?6W   $	??Top=?6k   $??90??6?   6?   ?? 5   
   -	   5        $ saveText??5      $??Save Text File??6#   $
??Left=?6<   $??300,325,0,0q?6W   $	??Top=?6l   $??90??6?   6?   5      5      