# CompositePattern-A-Simple-Game-of-Luck-Prototype
Composite Pattern kullanılarak geliştirilmiş olan basit bir şans oyununu içeren repo'dur.<br>
Bu oyunda oyuncu her tur, 4 cisimden birini seçer. Her seçenekte bir çanta veya bir ödül olabilir. Çanta seçildiğinde Çanta'nın içerisinde bulunan 4 adet yeni cisim ekrana gelir. Oyuncu bir ödül seçene kadar oyun devam eder. Her çanta açılışında çarpan artar. Ödül seçildiğinde ödülün değeri ile bu çarpan çarpılır. Amaç en yüksek parayı kazanmaktır.<br>

<b>---RewardTree---</b><br>
<b>RewardComponent.cs</b> => Composite Pattern'de tanımlanacak Tree'nin her bir elemanını temsil eden soyut sınıftır. Composite pattern gereği, elemanlar bir leaf yani sadece kendisini içeren bir sınıf olabilir. Veya bir branch yani başka RewardComponent'lar içeren bir sınıf olabilir. Bu şekilde bir ağaç yapısı oluşturulmaktadır.<br>
<b>Leaf.cs</b> => Ağacın yaprağı olarak düşünülebilir. Ödülün seçilmesi işlemleri çalıştırılır.<br>
<b>Branch.cs</b> => Ağacın dalı olarak düşünülebilir. Bu branch'e bağlı tüm RewardComponent'ların Operation metodunu çağırarak ağaçta ilerlememizi sağlar.<br><br>

<b>---ChoiceObjects---</b><br>
<b>RewardObject.cs</b> => Seçilecek olan cisimler bir RewardObject'tir. Reward Object Start metodunda rastgele bir cisim seçilir. Bu soyut sınıftan, Bat.cs, BeerMug.cs, Binoculars.cs gibi farklı ödüller türetilmiştir.<br><br>

<b>---Gameflow---</b><br>
<b>BoardManager.cs</b> => Bu sınıf InputHandler'ı dinleyerek oyuncu bir cisme tıkladığında tıklanan cisme göre bir algoritma çalıştırır. Eğer Briefcase tipinde bir cisme tıklandıysa, yeni cisimler spawn edilir, diğer türde bir cisme tıklandıysa ödül hesaplamasına geçilir. PopulateRewardTree metodu ile 1 adet Branch'e 4 adet RewardComponent ekliyoruz. Bu 4 RewardComponent Leaf veya Branch olabilir. Leaf ise Ödüldür. Branch ise Çantadır. Ardından atamaları yapıyoruz(Operation(rewardObjectList)).<br><br>

<b>---Input---</b><br>
<b>InputHandler.cs</b> => Player'ın tıkladığı cismi tespit edip OnGameObjectClicked event'i ile yayınlayan sınıftır.<br><br>

<b>---UI---</b><br>



