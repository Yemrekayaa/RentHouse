

		function c(passed_month, passed_year, calNum) {
			var calendar = calNum == 0 ? calendars.cal1 : calendars.cal2;
			makeWeek(calendar.weekline);
			calendar.datesBody.empty();
			var calMonthArray = makeMonthArray(passed_month, passed_year);
			var r = 0;
			var u = false;
			while(!u) {
				if(daysArray[r] == calMonthArray[0].weekday) { u = true } 
				else { 
					calendar.datesBody.append('<div class="blank"></div>');
					r++;
				}
			} 
			for(var cell=0;cell<42-r;cell++) { // 42 date-cells in calendar
				if(cell >= calMonthArray.length) {
					calendar.datesBody.append('<div class="blank"></div>');
				} else {
					var shownDate = calMonthArray[cell].day;
					// Later refactiroing -- iter_date not needed after "today" is found
					var iter_date = new Date(passed_year,passed_month,shownDate); 
					if ( 
						(
							( shownDate != today.getDate() && passed_month == today.getMonth() ) 
							|| passed_month != today.getMonth()
						) 
							&& iter_date < today) {						
						var m = '<div class="past-date">';
					} else {
						var m = checkToday(iter_date)?'<div class="today">':"<div>";
					}
					calendar.datesBody.append(m + shownDate + "</div>");
				}
			}

			
			calendar.calHeader.find("h2").text(i[passed_month]+" "+passed_year);

			

			
		}
		var testSelected = []
		function selectDateRange(startDate, endDate) {
			
			
			
			var startYear = startDate.getFullYear();
			var startMonth = startDate.getMonth();
			var startDay = startDate.getDate();
			
			var endYear = endDate.getFullYear();
			var endMonth = endDate.getMonth();
			var endDay = endDate.getDate();
			
			for (var year = startYear; year <= endYear; year++) {
				var monthStart = (year === startYear) ? startMonth : 0;
				var monthEnd = (year === endYear) ? endMonth : 11;
				
				for (var month = monthStart; month <= monthEnd; month++) {
					if (!selected[year]) {
						selected[year] = {};
					}
					selected[year][month] = [];
		
					var dayStart = (year === startYear && month === startMonth) ? startDay : 1;
					var dayEnd = (year === endYear && month === endMonth) ? endDay : getDaysInMonth(year, month);
		
					for (var day = dayStart; day <= dayEnd; day++) {
						selected[year][month].push(day);
					}
				}
			}
			testSelected.push(selected);
			selected = {};
			// Seçilen tarihleri vurgula
			selectDates(testSelected);
		}

function selectDates(selectedArray) {
	selectedArray.forEach(function (item) {
		
			var dateElements1 = datesBody1.find('div');
			var dateElements2 = datesBody2.find('div');

			function highlightDates(passed_year, passed_month, dateElements) {
				if (passed_year in item && passed_month in item[passed_year]) {
					var daysToCompare = item[passed_year][passed_month];
					// console.log(daysToCompare);
					for (var d in daysToCompare) {
						dateElements.each(function (index) {
							if (parseInt($(this).text()) == daysToCompare[d]) {
								$(this).addClass('selected');
							}
						});
					}

				}
			}

			highlightDates(year, month, dateElements1);
			highlightDates(nextYear, nextMonth, dateElements2);
		
	});
			
		}

		function makeMonthArray(passed_month, passed_year) { // creates Array specifying dates and weekdays
			var e=[];
			for(var r=1;r<getDaysInMonth(passed_year, passed_month)+1;r++) {
				e.push({day: r,
						// Later refactor -- weekday needed only for first week
						weekday: daysArray[getWeekdayNum(passed_year,passed_month,r)]
					});
			}
			return e;
		}
		function makeWeek(week) {
			week.empty();
			for(var e=0;e<7;e++) { 
				week.append("<div>"+daysArray[e].substring(0,3)+"</div>") 
			}
		}

		function getDaysInMonth(currentYear,currentMon) {
			return(new Date(currentYear,currentMon+1,0)).getDate();
		}
		function getWeekdayNum(e,t,n) {
			return(new Date(e,t,n)).getDay();
		}
		function checkToday(e) {
			var todayDate = today.getFullYear()+'/'+(today.getMonth()+1)+'/'+today.getDate();
			var checkingDate = e.getFullYear()+'/'+(e.getMonth()+1)+'/'+e.getDate();
			return todayDate==checkingDate;

		}
		function getAdjacentMonth(curr_month, curr_year, direction) {
			var theNextMonth;
			var theNextYear;
			if (direction == "next") {
				theNextMonth = (curr_month + 1) % 12;
				theNextYear = (curr_month == 11) ? curr_year + 1 : curr_year;
			} else {
				theNextMonth = (curr_month == 0) ? 11 : curr_month - 1;
				theNextYear = (curr_month == 0) ? curr_year - 1 : curr_year;
			}
			return [theNextMonth, theNextYear];
		}
		function b() {
			today = new Date;
			year = today.getFullYear();
			month = today.getMonth();
			var nextDates = getAdjacentMonth(month, year, "next");
			nextMonth = nextDates[0];
			nextYear = nextDates[1];
		}

		var e=480;

		var today;
		var year,
			month,
			nextMonth,
			nextYear;

		//var t=2013;
		//var n=9;
		var r = [];
		var i = ["Ocak", "Şubat", "Mart", "Nisan", "Mayıs",
				"Haziran", "Temmuz", "Ağustos", "Eylül", "Ekim",
				"Kasım", "Aralık"];
		var daysArray = ["Paz", "Pzt", "Sal", "Çar",
						 "Per", "Cum", "Cmt"];

		var o = ["#16a085","#1abc9c","#c0392b","#27ae60",
				"#FF6860","#f39c12","#f1c40f","#e67e22",
				"#2ecc71","#e74c3c","#d35400","#2c3e50"];
		
		var cal1=$("#calendar_first");
		var calHeader1=cal1.find(".calendar_header");
		var weekline1=cal1.find(".calendar_weekdays");
		var datesBody1=cal1.find(".calendar_content");

		var cal2=$("#calendar_second");
		var calHeader2=cal2.find(".calendar_header");
		var weekline2=cal2.find(".calendar_weekdays");
		var datesBody2=cal2.find(".calendar_content");

		var bothCals = $(".calendar");

		var switchButton = bothCals.find(".calendar_header").find('.switch-month');

		var calendars = { 
						"cal1": { 	"name": "first",
									"calHeader": calHeader1,
									"weekline": weekline1,
									"datesBody": datesBody1 },
						"cal2": { 	"name": "second",
									"calHeader": calHeader2,
									"weekline": weekline2,
									"datesBody": datesBody2	}
						}
		

		var clickedElement;
		var firstClicked,
			secondClicked,
			thirdClicked;
		var firstClick = false;
		var secondClick = false;	
		var selected = {};

		b();
		c(month, year, 0);
		c(nextMonth, nextYear, 1);
		switchButton.on("click",function() {
			var clicked=$(this);
			var generateCalendars = function(e) {
				var nextDatesFirst = getAdjacentMonth(month, year, e);
				var nextDatesSecond = getAdjacentMonth(nextMonth, nextYear, e);
				month = nextDatesFirst[0];
				year = nextDatesFirst[1];
				nextMonth = nextDatesSecond[0];
				nextYear = nextDatesSecond[1];

				c(month, year, 0);
				c(nextMonth, nextYear, 1);
			};
			if(clicked.attr("class").indexOf("left")!=-1) { 
				generateCalendars("previous");
			} else { generateCalendars("next"); }
			clickedElement = bothCals.find(".calendar_content").find("div");
			selectDates(testSelected);
		});




		// Finding between dates MADNESS. Needs refactoring and smartening up :)
		function addChosenDates(firstClicked, secondClicked, selected) {
			if (secondClicked.date > firstClicked.date || 
				secondClicked.month > firstClicked.month ||
				secondClicked.year > firstClicked.year) {

				var added_year = secondClicked.year;
				var added_month = secondClicked.month;
				var added_date = secondClicked.date;
				console.log(selected);

				if (added_year > firstClicked.year) {	
					// first add all dates from all months of Second-Clicked-Year
					selected[added_year] = {};
					selected[added_year][added_month] = [];
					for (var i = 1; 
						i <= secondClicked.date;
						i++) {
						selected[added_year][added_month].push(i);
					}
			
					added_month = added_month - 1;
					console.log(added_month);
					while (added_month >= 0) {
						selected[added_year][added_month] = [];
						for (var i = 1; 
							i <= getDaysInMonth(added_year, added_month);
							i++) {
							selected[added_year][added_month].push(i);
						}
						added_month = added_month - 1;
					}

					added_year = added_year - 1;
					added_month = 11; // reset month to Dec because we decreased year
					added_date = getDaysInMonth(added_year, added_month); // reset date as well

					// Now add all dates from all months of inbetween years
					while (added_year > firstClicked.year) {
						selected[added_year] = {};
						for (var i=0; i < 12; i++) {
							selected[added_year][i] = [];
							for (var d = 1; d <= getDaysInMonth(added_year, i); d++) {
								selected[added_year][i].push(d);
							}
						}
						added_year = added_year - 1;
					}
				}
				
				if (added_month > firstClicked.month) {
					if (firstClicked.year == secondClicked.year) {
						console.log("here is the month:",added_month);
						selected[added_year][added_month] = [];
						for (var i = 1; 
							i <= secondClicked.date;
							i++) {
							selected[added_year][added_month].push(i);
						}
						added_month = added_month - 1;
					}
					while (added_month > firstClicked.month) {
						selected[added_year][added_month] = [];
						for (var i = 1; 
							i <= getDaysInMonth(added_year, added_month);
							i++) {
							selected[added_year][added_month].push(i);
						}
						added_month = added_month - 1;
					}
					added_date = getDaysInMonth(added_year, added_month);
				}

				for (var i = firstClicked.date + 1; 
					i <= added_date;
					i++) {
					selected[added_year][added_month].push(i);
				}
			}
			
			return selected;
		}


