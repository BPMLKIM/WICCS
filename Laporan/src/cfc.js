d = new dTree('d');
d.config.closeSameLevel=true;
d.config.useIcons=false;
d.config.folderLinks = false;
d.add(0,-1,'');
d.add(1,0,'Laporan Caj','');		
d.add(2,1,'Laporan Caj Kenderaan Masuk Melalui Pintu Import','Papar_Pilihan.aspx?id=48&RptH=ICCS_CAJ01.rpt&RptB=ICCS_CAJ05.rpt&RptT=ICCS_CAJ09.rpt');		
d.add(3,1,'Laporan Caj Kenderaan Masuk Melalui Pintu Eksport','Papar_Pilihan.aspx?id=49&RptH=ICCS_CAJ02.rpt&RptB=ICCS_CAJ05.rpt&RptT=ICCS_CAJ09.rpt');		
d.add(4,1,'Laporan Caj Ikan Import / Transit (Kaunter Bayaran)','Papar_Pilihan.aspx?id=50&RptH=ICCS_CAJ03.rpt&RptB=ICCS_CAJ06.rpt&RptT=ICCS_CAJ10.rpt');		
d.add(5,1,'Laporan Caj Ikan Import / Transit Dengan Rebat KIBFG(Kaunter Bayaran)','Papar_Pilihan.aspx?id=52&RptH=ICCS_CAJ03_K.rpt&RptB=ICCS_CAJ06_K.rpt&RptT=ICCS_CAJ10_K.rpt');
d.add(6,1,'Laporan Import/Eksport/Transit (Caj Borang e-SKPI)','Papar_Pilihan.aspx?id=51&RptH=ICCS_CAJ04.rpt&RptB=ICCS_CAJ07.rpt&RptT=ICCS_CAJ11.rpt');		
d.add(7,1,'Laporan Import/Eksport/Transit (Caj Borang e-SKPI) Bagi Status batal','Papar_Pilihan.aspx?id=54&RptH=ICCS_CAJ04Batal.rpt&RptB=ICCS_CAJ07Batal.rpt&RptT=ICCS_CAJ11Batal.rpt');		
d.add(8,1,'Laporan Bilangan Kotak Biru Kecil dan Kotak Biru Besar','Papar_Pilihan.aspx?id=53&RptH=ICCS_CAJ03_K1.rpt&RptB=ICCS_CAJ06_K1.rpt&RptT=ICCS_CAJ10_K1.rpt');
//edited by kmz for caj eksport
d.add(9,1,'Laporan Caj Ikan Eksport / Transit (Kaunter Bayaran)','Papar_Pilihan.aspx?id=501&RptH=ICCS_CAJ03E.rpt&RptB=ICCS_CAJ06E.rpt&RptT=ICCS_CAJ10E.rpt');		
//d.add(8,1,'Laporan Kutipan Caj Borang SKPI Mengikut Pengimport','Papar_Pilihan.aspx?id=54&RptH=ICCS_CAJ15.rpt&RptB=ICCS_CAJ15B.rpt&RptT=ICCS_CAJ15T.rpt');

document.write(d);
