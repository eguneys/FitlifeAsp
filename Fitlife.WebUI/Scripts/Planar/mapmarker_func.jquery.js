$(document).ready(function(){
	
		//set up markers 
		var myMarkers = {"markers": [
				{"latitude": "34.095085", "longitude":"-118.281671", "icon": "img/map-marker.png", "baloon_text": '<strong>PLANAR</strong> 1110 Bates Avenue Los Angeles, CA 90029, US'}
			]
		};
		
		//set up map options
		$("#map").mapmarker({
			zoom	: 11,
			center	: '1110 Bates Avenue Los Angeles, CA 90029, United States',
			markers	: myMarkers
		});

	});