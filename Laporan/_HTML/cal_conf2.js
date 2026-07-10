
//Define calendar(s): addCalendar ("Unique Calendar Name", "Window title", "Form element's name", Form name")
addCalendar("Calendar1", "Sila Pilih Tarikh", "txttarikh1", "Form1");
addCalendar("Calendar2", "Sila Pilih Tarikh", "txttarikh2", "Form1");
addCalendar("Calendar3", "Sila Pilih Tarikh", "txttarikh3", "Form1");
addCalendar("Calendar4", "Sila Pilih Tarikh", "txttarikh4", "Form1");
addCalendar("Calendar5", "Sila Pilih Tarikh", "txttarikh5", "Form1");
addCalendar("Calendar6", "Sila Pilih Tarikh", "txttarikh6", "Form1");
addCalendar("Calendar7", "Sila Pilih Tarikh", "txttarikh7", "Form1");
addCalendar("Calendar8", "Sila Pilih Tarikh", "txttarikh8", "Form1");

// default settings for English
// Uncomment desired lines and modify its values
// setFont("verdana", 9);
setFont("Century Gothic", 9);
 setWidth(90, 1, 15, 1);
// setColor("#cccccc", "#cccccc", "#ffffff", "#ffffff", "#333333", "#cccccc", "#333333");
setColor("black", "blue", "#3399FF", "white","#FFFF00", "#3333CC","blue");
// setFontColor("#333333", "#333333", "#333333", "#ffffff", "#333333");
setFontColor("white","white","black","black","white");
// setFormat("yyyy/mm/dd");
setFormat("dd/mm/yyyy");
// setSize(200, 200, -200, 16);

// setWeekDay(0);

// setMonthNames("January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December");
setMonthNames("Januari", "Februari", "Mac", "April", "Mei", "Jun", "Julai", "Ogos", "September", "Oktober", "November", "Disember");

// setDayNames("Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday");
setDayNames("Ahad", "Isnin", "Selasa", "Rabu", "Khamis", "Jumaat", "Sabtu");

// setLinkNames("[Close]", "[Clear]");
setLinkNames("[Tutup]","[Kosongkan]");
