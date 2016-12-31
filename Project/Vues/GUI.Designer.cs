/*
 * Created by SharpDevelop.
 * User: C357555
 * Date: 15/11/2011
 * Time: 12:06
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Assistant
{
	partial class GUI
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GUI));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.imageListToolStrip = new System.Windows.Forms.ImageList(this.components);
            this.imageListToolStrip32 = new System.Windows.Forms.ImageList(this.components);
            this.imageListLevel = new System.Windows.Forms.ImageList(this.components);
            this.imageListAvatar = new System.Windows.Forms.ImageList(this.components);
            this.imageListNation = new System.Windows.Forms.ImageList(this.components);
            this.imageListCalendar = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Size = new System.Drawing.Size(292, 266);
            this.splitContainer1.SplitterDistance = 100;
            this.splitContainer1.TabIndex = 0;
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "nopicture");
            this.imageList.Images.SetKeyName(1, "delete");
            this.imageList.Images.SetKeyName(2, "edit");
            // 
            // imageListToolStrip
            // 
            this.imageListToolStrip.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListToolStrip.ImageStream")));
            this.imageListToolStrip.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListToolStrip.Images.SetKeyName(0, "team_new");
            this.imageListToolStrip.Images.SetKeyName(1, "team_open");
            this.imageListToolStrip.Images.SetKeyName(2, "team_edit");
            this.imageListToolStrip.Images.SetKeyName(3, "team_add_user");
            this.imageListToolStrip.Images.SetKeyName(4, "team_new_user");
            this.imageListToolStrip.Images.SetKeyName(5, "team_del_user");
            this.imageListToolStrip.Images.SetKeyName(6, "oncall");
            this.imageListToolStrip.Images.SetKeyName(7, "hotline");
            this.imageListToolStrip.Images.SetKeyName(8, "settings");
            this.imageListToolStrip.Images.SetKeyName(9, "chief");
            this.imageListToolStrip.Images.SetKeyName(10, "location");
            this.imageListToolStrip.Images.SetKeyName(11, "service");
            this.imageListToolStrip.Images.SetKeyName(12, "name");
            this.imageListToolStrip.Images.SetKeyName(13, "compagny");
            this.imageListToolStrip.Images.SetKeyName(14, "year");
            this.imageListToolStrip.Images.SetKeyName(15, "user");
            this.imageListToolStrip.Images.SetKeyName(16, "exportFolder");
            this.imageListToolStrip.Images.SetKeyName(17, "exportFast");
            this.imageListToolStrip.Images.SetKeyName(18, "export");
            this.imageListToolStrip.Images.SetKeyName(19, "userSetting");
            this.imageListToolStrip.Images.SetKeyName(20, "calendarSetting");
            this.imageListToolStrip.Images.SetKeyName(21, "teamSetting");
            // 
            // imageListToolStrip32
            // 
            this.imageListToolStrip32.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListToolStrip32.ImageStream")));
            this.imageListToolStrip32.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListToolStrip32.Images.SetKeyName(0, "user_new");
            this.imageListToolStrip32.Images.SetKeyName(1, "user_open");
            this.imageListToolStrip32.Images.SetKeyName(2, "team_new");
            this.imageListToolStrip32.Images.SetKeyName(3, "team_open");
            this.imageListToolStrip32.Images.SetKeyName(4, "exportFast");
            this.imageListToolStrip32.Images.SetKeyName(5, "export");
            this.imageListToolStrip32.Images.SetKeyName(6, "exportFolder");
            this.imageListToolStrip32.Images.SetKeyName(7, "settings");
            this.imageListToolStrip32.Images.SetKeyName(8, "userSetting");
            this.imageListToolStrip32.Images.SetKeyName(9, "teamSetting");
            this.imageListToolStrip32.Images.SetKeyName(10, "planningSingle");
            this.imageListToolStrip32.Images.SetKeyName(11, "planningMultiOld");
            this.imageListToolStrip32.Images.SetKeyName(12, "planningMulti");
            this.imageListToolStrip32.Images.SetKeyName(13, "year");
            this.imageListToolStrip32.Images.SetKeyName(14, "add");
            this.imageListToolStrip32.Images.SetKeyName(15, "color");
            this.imageListToolStrip32.Images.SetKeyName(16, "manager");
            // 
            // imageListLevel
            // 
            this.imageListLevel.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListLevel.ImageStream")));
            this.imageListLevel.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListLevel.Images.SetKeyName(0, "lvl_0.png");
            this.imageListLevel.Images.SetKeyName(1, "lvl_1.png");
            this.imageListLevel.Images.SetKeyName(2, "lvl_2.png");
            this.imageListLevel.Images.SetKeyName(3, "lvl_3.png");
            this.imageListLevel.Images.SetKeyName(4, "lvl_4.png");
            this.imageListLevel.Images.SetKeyName(5, "lvl_5.png");
            this.imageListLevel.Images.SetKeyName(6, "lvl_6.png");
            this.imageListLevel.Images.SetKeyName(7, "lvl_7.png");
            // 
            // imageListAvatar
            // 
            this.imageListAvatar.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListAvatar.ImageStream")));
            this.imageListAvatar.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListAvatar.Images.SetKeyName(0, "default");
            this.imageListAvatar.Images.SetKeyName(1, "astronaut");
            this.imageListAvatar.Images.SetKeyName(2, "batman");
            this.imageListAvatar.Images.SetKeyName(3, "blondy");
            this.imageListAvatar.Images.SetKeyName(4, "catwomen");
            this.imageListAvatar.Images.SetKeyName(5, "chief");
            this.imageListAvatar.Images.SetKeyName(6, "chief_female");
            this.imageListAvatar.Images.SetKeyName(7, "clown");
            this.imageListAvatar.Images.SetKeyName(8, "female");
            this.imageListAvatar.Images.SetKeyName(9, "gray");
            this.imageListAvatar.Images.SetKeyName(10, "green");
            this.imageListAvatar.Images.SetKeyName(11, "jew");
            this.imageListAvatar.Images.SetKeyName(12, "king");
            this.imageListAvatar.Images.SetKeyName(13, "maid");
            this.imageListAvatar.Images.SetKeyName(14, "medical");
            this.imageListAvatar.Images.SetKeyName(15, "medical_female");
            this.imageListAvatar.Images.SetKeyName(16, "ninja");
            this.imageListAvatar.Images.SetKeyName(17, "nude");
            this.imageListAvatar.Images.SetKeyName(18, "nude_female");
            this.imageListAvatar.Images.SetKeyName(19, "orange");
            this.imageListAvatar.Images.SetKeyName(20, "police_england");
            this.imageListAvatar.Images.SetKeyName(21, "police_female");
            this.imageListAvatar.Images.SetKeyName(22, "policeman");
            this.imageListAvatar.Images.SetKeyName(23, "queen");
            this.imageListAvatar.Images.SetKeyName(24, "red");
            this.imageListAvatar.Images.SetKeyName(25, "sailor");
            this.imageListAvatar.Images.SetKeyName(26, "silhouette");
            this.imageListAvatar.Images.SetKeyName(27, "soldier");
            this.imageListAvatar.Images.SetKeyName(28, "student");
            this.imageListAvatar.Images.SetKeyName(29, "student_female");
            this.imageListAvatar.Images.SetKeyName(30, "suit");
            this.imageListAvatar.Images.SetKeyName(31, "vietnamese");
            this.imageListAvatar.Images.SetKeyName(32, "zorro");
            // 
            // imageListNation
            // 
            this.imageListNation.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListNation.ImageStream")));
            this.imageListNation.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListNation.Images.SetKeyName(0, "default");
            this.imageListNation.Images.SetKeyName(1, "afghanistan");
            this.imageListNation.Images.SetKeyName(2, "albania");
            this.imageListNation.Images.SetKeyName(3, "algeria");
            this.imageListNation.Images.SetKeyName(4, "american_samoa");
            this.imageListNation.Images.SetKeyName(5, "andorra");
            this.imageListNation.Images.SetKeyName(6, "angola");
            this.imageListNation.Images.SetKeyName(7, "anguilla");
            this.imageListNation.Images.SetKeyName(8, "antigua_and_barbuda");
            this.imageListNation.Images.SetKeyName(9, "argentina");
            this.imageListNation.Images.SetKeyName(10, "armenia");
            this.imageListNation.Images.SetKeyName(11, "aruba");
            this.imageListNation.Images.SetKeyName(12, "australia");
            this.imageListNation.Images.SetKeyName(13, "austria");
            this.imageListNation.Images.SetKeyName(14, "azerbaijan");
            this.imageListNation.Images.SetKeyName(15, "bahamas");
            this.imageListNation.Images.SetKeyName(16, "bahrain");
            this.imageListNation.Images.SetKeyName(17, "bangladesh");
            this.imageListNation.Images.SetKeyName(18, "barbados");
            this.imageListNation.Images.SetKeyName(19, "belarus");
            this.imageListNation.Images.SetKeyName(20, "belgium");
            this.imageListNation.Images.SetKeyName(21, "belize");
            this.imageListNation.Images.SetKeyName(22, "benin");
            this.imageListNation.Images.SetKeyName(23, "bermuda");
            this.imageListNation.Images.SetKeyName(24, "bhutan");
            this.imageListNation.Images.SetKeyName(25, "bolivia");
            this.imageListNation.Images.SetKeyName(26, "bosnia");
            this.imageListNation.Images.SetKeyName(27, "botswana");
            this.imageListNation.Images.SetKeyName(28, "brazil");
            this.imageListNation.Images.SetKeyName(29, "british_indian_ocean");
            this.imageListNation.Images.SetKeyName(30, "british_virgin_islands");
            this.imageListNation.Images.SetKeyName(31, "brunei");
            this.imageListNation.Images.SetKeyName(32, "bulgaria");
            this.imageListNation.Images.SetKeyName(33, "burkina_faso");
            this.imageListNation.Images.SetKeyName(34, "burma");
            this.imageListNation.Images.SetKeyName(35, "burundi");
            this.imageListNation.Images.SetKeyName(36, "cambodia");
            this.imageListNation.Images.SetKeyName(37, "cameroon");
            this.imageListNation.Images.SetKeyName(38, "canada");
            this.imageListNation.Images.SetKeyName(39, "cayman_islands");
            this.imageListNation.Images.SetKeyName(40, "central_african_republic");
            this.imageListNation.Images.SetKeyName(41, "chad");
            this.imageListNation.Images.SetKeyName(42, "chile");
            this.imageListNation.Images.SetKeyName(43, "china");
            this.imageListNation.Images.SetKeyName(44, "colombia");
            this.imageListNation.Images.SetKeyName(45, "comoros");
            this.imageListNation.Images.SetKeyName(46, "congo_democratic_republic");
            this.imageListNation.Images.SetKeyName(47, "congo_republic");
            this.imageListNation.Images.SetKeyName(48, "cook_islands");
            this.imageListNation.Images.SetKeyName(49, "cope_verde");
            this.imageListNation.Images.SetKeyName(50, "costa_rica");
            this.imageListNation.Images.SetKeyName(51, "cote_divoire");
            this.imageListNation.Images.SetKeyName(52, "croatia");
            this.imageListNation.Images.SetKeyName(53, "cuba");
            this.imageListNation.Images.SetKeyName(54, "cyprus");
            this.imageListNation.Images.SetKeyName(55, "czech_republic");
            this.imageListNation.Images.SetKeyName(56, "denmark");
            this.imageListNation.Images.SetKeyName(57, "djibouti");
            this.imageListNation.Images.SetKeyName(58, "dominica");
            this.imageListNation.Images.SetKeyName(59, "dominican_republic");
            this.imageListNation.Images.SetKeyName(60, "east_timor");
            this.imageListNation.Images.SetKeyName(61, "egypt");
            this.imageListNation.Images.SetKeyName(62, "el_salvador");
            this.imageListNation.Images.SetKeyName(63, "england");
            this.imageListNation.Images.SetKeyName(64, "equador");
            this.imageListNation.Images.SetKeyName(65, "equatorial_guinea");
            this.imageListNation.Images.SetKeyName(66, "eritrea");
            this.imageListNation.Images.SetKeyName(67, "estonia");
            this.imageListNation.Images.SetKeyName(68, "ethiopia");
            this.imageListNation.Images.SetKeyName(69, "falkland_islands");
            this.imageListNation.Images.SetKeyName(70, "european_union");
            this.imageListNation.Images.SetKeyName(71, "faroe_islands");
            this.imageListNation.Images.SetKeyName(72, "fiji");
            this.imageListNation.Images.SetKeyName(73, "finish");
            this.imageListNation.Images.SetKeyName(74, "finland");
            this.imageListNation.Images.SetKeyName(75, "france");
            this.imageListNation.Images.SetKeyName(76, "french_polynesia");
            this.imageListNation.Images.SetKeyName(77, "gabon");
            this.imageListNation.Images.SetKeyName(78, "gambia");
            this.imageListNation.Images.SetKeyName(79, "georgia");
            this.imageListNation.Images.SetKeyName(80, "germany");
            this.imageListNation.Images.SetKeyName(81, "ghana");
            this.imageListNation.Images.SetKeyName(82, "gibraltar");
            this.imageListNation.Images.SetKeyName(83, "great_britain");
            this.imageListNation.Images.SetKeyName(84, "greece");
            this.imageListNation.Images.SetKeyName(85, "greenland");
            this.imageListNation.Images.SetKeyName(86, "grenada");
            this.imageListNation.Images.SetKeyName(87, "guam");
            this.imageListNation.Images.SetKeyName(88, "guatemala");
            this.imageListNation.Images.SetKeyName(89, "guernsey");
            this.imageListNation.Images.SetKeyName(90, "guinea");
            this.imageListNation.Images.SetKeyName(91, "guinea_bissau");
            this.imageListNation.Images.SetKeyName(92, "guyana");
            this.imageListNation.Images.SetKeyName(93, "haiti");
            this.imageListNation.Images.SetKeyName(94, "honduras");
            this.imageListNation.Images.SetKeyName(95, "hong_kong");
            this.imageListNation.Images.SetKeyName(96, "hungary");
            this.imageListNation.Images.SetKeyName(97, "iceland");
            this.imageListNation.Images.SetKeyName(98, "india");
            this.imageListNation.Images.SetKeyName(99, "indonesia");
            this.imageListNation.Images.SetKeyName(100, "iran");
            this.imageListNation.Images.SetKeyName(101, "iraq");
            this.imageListNation.Images.SetKeyName(102, "ireland");
            this.imageListNation.Images.SetKeyName(103, "isle_of_man");
            this.imageListNation.Images.SetKeyName(104, "israel");
            this.imageListNation.Images.SetKeyName(105, "italy");
            this.imageListNation.Images.SetKeyName(106, "jamaica");
            this.imageListNation.Images.SetKeyName(107, "japan");
            this.imageListNation.Images.SetKeyName(108, "jersey");
            this.imageListNation.Images.SetKeyName(109, "jordan");
            this.imageListNation.Images.SetKeyName(110, "kazakhstan");
            this.imageListNation.Images.SetKeyName(111, "kenya");
            this.imageListNation.Images.SetKeyName(112, "kiribati");
            this.imageListNation.Images.SetKeyName(113, "kuwait");
            this.imageListNation.Images.SetKeyName(114, "kyrgyzstan");
            this.imageListNation.Images.SetKeyName(115, "laos");
            this.imageListNation.Images.SetKeyName(116, "latvia");
            this.imageListNation.Images.SetKeyName(117, "lebanon");
            this.imageListNation.Images.SetKeyName(118, "lesotho");
            this.imageListNation.Images.SetKeyName(119, "liberia");
            this.imageListNation.Images.SetKeyName(120, "libya");
            this.imageListNation.Images.SetKeyName(121, "liechtenstein");
            this.imageListNation.Images.SetKeyName(122, "lithuania");
            this.imageListNation.Images.SetKeyName(123, "luxembourg");
            this.imageListNation.Images.SetKeyName(124, "macau");
            this.imageListNation.Images.SetKeyName(125, "macedonia");
            this.imageListNation.Images.SetKeyName(126, "madagascar");
            this.imageListNation.Images.SetKeyName(127, "malawi");
            this.imageListNation.Images.SetKeyName(128, "malaysia");
            this.imageListNation.Images.SetKeyName(129, "maledives");
            this.imageListNation.Images.SetKeyName(130, "mali");
            this.imageListNation.Images.SetKeyName(131, "malta");
            this.imageListNation.Images.SetKeyName(132, "marshall_islands");
            this.imageListNation.Images.SetKeyName(133, "martinique");
            this.imageListNation.Images.SetKeyName(134, "mauretania");
            this.imageListNation.Images.SetKeyName(135, "mauritius");
            this.imageListNation.Images.SetKeyName(136, "mexico");
            this.imageListNation.Images.SetKeyName(137, "micronesia");
            this.imageListNation.Images.SetKeyName(138, "moldova");
            this.imageListNation.Images.SetKeyName(139, "monaco");
            this.imageListNation.Images.SetKeyName(140, "mongolia");
            this.imageListNation.Images.SetKeyName(141, "montserrat");
            this.imageListNation.Images.SetKeyName(142, "morocco");
            this.imageListNation.Images.SetKeyName(143, "mozambique");
            this.imageListNation.Images.SetKeyName(144, "namibia");
            this.imageListNation.Images.SetKeyName(145, "nato");
            this.imageListNation.Images.SetKeyName(146, "nauru");
            this.imageListNation.Images.SetKeyName(147, "nepal");
            this.imageListNation.Images.SetKeyName(148, "netherlands");
            this.imageListNation.Images.SetKeyName(149, "netherlands_antilles");
            this.imageListNation.Images.SetKeyName(150, "new_zealand");
            this.imageListNation.Images.SetKeyName(151, "nicaragua");
            this.imageListNation.Images.SetKeyName(152, "niger");
            this.imageListNation.Images.SetKeyName(153, "nigeria");
            this.imageListNation.Images.SetKeyName(154, "niue");
            this.imageListNation.Images.SetKeyName(155, "norfolk_islands");
            this.imageListNation.Images.SetKeyName(156, "north_korea");
            this.imageListNation.Images.SetKeyName(157, "northern_mariana_islands");
            this.imageListNation.Images.SetKeyName(158, "norway");
            this.imageListNation.Images.SetKeyName(159, "oman");
            this.imageListNation.Images.SetKeyName(160, "pakistan");
            this.imageListNation.Images.SetKeyName(161, "palau");
            this.imageListNation.Images.SetKeyName(162, "panama");
            this.imageListNation.Images.SetKeyName(163, "papua_new_guinea");
            this.imageListNation.Images.SetKeyName(164, "paraquay");
            this.imageListNation.Images.SetKeyName(165, "peru");
            this.imageListNation.Images.SetKeyName(166, "philippines");
            this.imageListNation.Images.SetKeyName(167, "pitcairn_islands");
            this.imageListNation.Images.SetKeyName(168, "poland");
            this.imageListNation.Images.SetKeyName(169, "portugal");
            this.imageListNation.Images.SetKeyName(170, "puerto_rico");
            this.imageListNation.Images.SetKeyName(171, "qatar");
            this.imageListNation.Images.SetKeyName(172, "romania");
            this.imageListNation.Images.SetKeyName(173, "russia");
            this.imageListNation.Images.SetKeyName(174, "rwanda");
            this.imageListNation.Images.SetKeyName(175, "saint_helena");
            this.imageListNation.Images.SetKeyName(176, "saint_kitts_and_nevis");
            this.imageListNation.Images.SetKeyName(177, "saint_lucia");
            this.imageListNation.Images.SetKeyName(178, "saint_pierre_and_miquelon");
            this.imageListNation.Images.SetKeyName(179, "saint_vincent_and_grenadines");
            this.imageListNation.Images.SetKeyName(180, "samoa");
            this.imageListNation.Images.SetKeyName(181, "san_marino");
            this.imageListNation.Images.SetKeyName(182, "sao_tome_and_principe");
            this.imageListNation.Images.SetKeyName(183, "saudi_arabia");
            this.imageListNation.Images.SetKeyName(184, "scotland");
            this.imageListNation.Images.SetKeyName(185, "senegal");
            this.imageListNation.Images.SetKeyName(186, "serbia_montenegro");
            this.imageListNation.Images.SetKeyName(187, "seychelles");
            this.imageListNation.Images.SetKeyName(188, "sierra_leone");
            this.imageListNation.Images.SetKeyName(189, "singapore");
            this.imageListNation.Images.SetKeyName(190, "slovakia");
            this.imageListNation.Images.SetKeyName(191, "slovenia");
            this.imageListNation.Images.SetKeyName(192, "solomon_islands");
            this.imageListNation.Images.SetKeyName(193, "somalia");
            this.imageListNation.Images.SetKeyName(194, "south_africa");
            this.imageListNation.Images.SetKeyName(195, "south_georgia");
            this.imageListNation.Images.SetKeyName(196, "south_korea");
            this.imageListNation.Images.SetKeyName(197, "spain");
            this.imageListNation.Images.SetKeyName(198, "sri_lanka");
            this.imageListNation.Images.SetKeyName(199, "sudan");
            this.imageListNation.Images.SetKeyName(200, "suriname");
            this.imageListNation.Images.SetKeyName(201, "swaziland");
            this.imageListNation.Images.SetKeyName(202, "sweden");
            this.imageListNation.Images.SetKeyName(203, "switzerland");
            this.imageListNation.Images.SetKeyName(204, "syria");
            this.imageListNation.Images.SetKeyName(205, "taiwan");
            this.imageListNation.Images.SetKeyName(206, "tajikistan");
            this.imageListNation.Images.SetKeyName(207, "tanzania");
            this.imageListNation.Images.SetKeyName(208, "thailand");
            this.imageListNation.Images.SetKeyName(209, "tibet");
            this.imageListNation.Images.SetKeyName(210, "togo");
            this.imageListNation.Images.SetKeyName(211, "tonga");
            this.imageListNation.Images.SetKeyName(212, "trinidad_and_tobago");
            this.imageListNation.Images.SetKeyName(213, "tunisia");
            this.imageListNation.Images.SetKeyName(214, "turkey");
            this.imageListNation.Images.SetKeyName(215, "turkmenistan");
            this.imageListNation.Images.SetKeyName(216, "turks_and_caicos_islands");
            this.imageListNation.Images.SetKeyName(217, "tuvalu");
            this.imageListNation.Images.SetKeyName(218, "uganda");
            this.imageListNation.Images.SetKeyName(219, "ukraine");
            this.imageListNation.Images.SetKeyName(220, "unesco");
            this.imageListNation.Images.SetKeyName(221, "united_arab_emirates");
            this.imageListNation.Images.SetKeyName(222, "united_nations");
            this.imageListNation.Images.SetKeyName(223, "uruquay");
            this.imageListNation.Images.SetKeyName(224, "usa");
            this.imageListNation.Images.SetKeyName(225, "uzbekistan");
            this.imageListNation.Images.SetKeyName(226, "vanuatu");
            this.imageListNation.Images.SetKeyName(227, "vatican_city");
            this.imageListNation.Images.SetKeyName(228, "venezuela");
            this.imageListNation.Images.SetKeyName(229, "vietnam");
            this.imageListNation.Images.SetKeyName(230, "virgin_islands");
            this.imageListNation.Images.SetKeyName(231, "wales");
            this.imageListNation.Images.SetKeyName(232, "wallis_and_futuna");
            this.imageListNation.Images.SetKeyName(233, "wto");
            this.imageListNation.Images.SetKeyName(234, "wwf");
            this.imageListNation.Images.SetKeyName(235, "yemen");
            this.imageListNation.Images.SetKeyName(236, "zambia");
            this.imageListNation.Images.SetKeyName(237, "zimbabwe");
            // 
            // imageListCalendar
            // 
            this.imageListCalendar.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListCalendar.ImageStream")));
            this.imageListCalendar.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListCalendar.Images.SetKeyName(0, "default");
            this.imageListCalendar.Images.SetKeyName(1, "gregorian");
            this.imageListCalendar.Images.SetKeyName(2, "lunisolar");
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.splitContainer1);
            this.Name = "GUI";
            this.Text = "xcdw";
            this.Load += new System.EventHandler(this.GUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
        private System.Windows.Forms.SplitContainer splitContainer1;
        public System.Windows.Forms.ImageList imageListToolStrip32;
		public System.Windows.Forms.ImageList imageListToolStrip;
		public System.Windows.Forms.ImageList imageList;
		public System.Windows.Forms.ImageList imageListLevel;
        public System.Windows.Forms.ImageList imageListAvatar;
        public System.Windows.Forms.ImageList imageListNation;
        public System.Windows.Forms.ImageList imageListCalendar;
	}
}
