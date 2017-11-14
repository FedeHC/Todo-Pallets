/* ------------------------------------------- */
/*   Código JS para Todo-Pallets!              */
/* ------------------------------------------- */

$(document).ready(function() 
	{ 
		iniciar();
		slider1();
		slider2();
	}
);


function iniciar()	{
	$("#email-padres").hide();

	$("#link-arriba").click(function()	{
		$('html, body').animate({ scrollTop: 0 }, 'slow');
	});

	$("#edad-usuario").blur(function()	{
			var dato = $(this).val();
			var numero = Number(dato);

			if (numero < 14) {
				$("#email-padres").show();
			} else {
				$("#email-padres").hide();
			}
	});
}


function slider1() 
{
	$(document).ready(function ($)
	{
		// Distintas animaciones ("Caption Transitions") para los textos incorporados ("Captions"):
		var _CaptionTransitions =
		[
			{$Duration:1500,x:2,y:0.3,$Zoom:11,$Rotate:0.3,$Easing:{$Left:$JssorEasing$.$EaseInCubic,$Top:$JssorEasing$.$EaseOutWave},$Opacity:2},

			{$Duration:1200,x:0.6,y:0.6,$Zoom:11,$Rotate:-0.8,$Easing:{$Left:$JssorEasing$.$EaseInWave,$Top:$JssorEasing$.$EaseInJump,$Zoom:$JssorEasing$.$EaseInCubic},$Opacity:2,$During:{$Top:[0,0.5]},$Round:{$Left:0.3,$Top:0.5,$Rotate:0.4}},

			{$Duration:1200,x:0.3,y:0.3,$Zoom:1,$Easing:{$Left:$JssorEasing$.$EaseInJump,$Top:$JssorEasing$.$EaseInJump},$Opacity:2,$During:{$Left:[0,0.8],$Top:[0,0.8]},$Round:{$Left:0.8,$Top:0.8}}
		];

		// Opciones varias para el slider primario:
		var options =
		{
			$AutoPlay: true,
			$AutoPlayInterval: 10000,
			$Loop: 1,
			$FillMode: 0,
			$PauseOnHover: 1,
			$DragOrientation: 1,
			$ArrowKeyNavigation: true,
			$SlideDuration: 500,
			$StartIndex: 0,

			// Flechas de navegación para slider primario:
			$ArrowNavigatorOptions:
			{
				$Class: $JssorArrowNavigator$,
				$ChanceToShow: 1,
				$AutoCenter: 0,
				$Steps: 1
			},

			// Imagenes en miniatura para navegar:
			$ThumbnailNavigatorOptions:
			{
				$Class: $JssorThumbnailNavigator$,
				$ChanceToShow: 2,
				$ActionMode: 1,
				$AutoCenter: 3,
				$SpacingX: 0,
				$SpacingY: 0,
				$DisplayPieces: 10,
				$ParkingPosition: 0,
				$Orientation: 1,
				$DisableDrag: true
			},

			// Textos incorporados sobre las imagenes ("captions"):
			$CaptionSliderOptions:
			{
				$Class: $JssorCaptionSlider$,
				$CaptionTransitions: _CaptionTransitions,
				$PlayInMode: 1,
				$PlayOutMode: 3
			}
		};
		var jssor_slider1 = new $JssorSlider$('slider1_container', options);
		
		var nroSlideAnterior = "10";
		var nroSlideActual = "1";
		var nroSlideSiguiente = "2";
		var inicio = true;

		// Obteniendo los cambios de estado en el 'slider1' para producir los cambios necesarios en el
		// resto del cuerpo de la página:
		jssor_slider1.$On($JssorSlider$.$EVT_STATE_CHANGE, function(slideIndex, progress, progressBegin, idleBegin, idleEnd, progressEnd)
		{
			// Este bloque solo se ejecuta cuando se inicia la página por primera vez:
			if (inicio)
			{
				// Cambiando n° de TOP al número 1, por ser la primera vez:
				document.getElementById("numero-slide-invisible").innerHTML = "TOP <b>1</b>:";

				// 'inicio' se cambia para no volver nunca más a este ciclo 'if':
				inicio = false;
			}
			else
			{
				if (progress == progressBegin)
				{
					nroSlideAnterior = nroSlideActual;
					nroSlideActual = jssor_slider1.$CurrentIndex() + 1;
					if (nroSlideActual != 10)
					{
						nroSlideSiguiente = jssor_slider1.$CurrentIndex() + 2;
					}
					else
					{
						nroSlideSiguiente = 1;
					}

					// Cambiando n° de TOP en descripción, según la foto actual del slider principal:
					document.getElementById("numero-slide-invisible").innerHTML = "TOP <b>" + nroSlideActual + ":</b>";

					// -Se oculta la descripción vieja del slider previo-
					// Cambiando en el título el nombre del producto/proyecto:
					document.getElementById("titulo-" + nroSlideAnterior).style.display = "none";

					// Cambiando el precio o autro del producto/proyecto:
					document.getElementById("precio-" + nroSlideAnterior).style.display = "none";

					// Columna izquierda:
					document.getElementById("columna-descripcion-" + nroSlideAnterior + "-izq").style.display = "none";
					// document.getElementById("columna-descripcion-" + nroSlideAnterior + "-izq").style.visibility = "hidden";
					// document.getElementById("columna-descripcion-" + nroSlideAnterior + "-izq").style.opacity = "0";
					// document.getElementById("columna-descripcion-" + nroSlideAnterior + "-izq").style.transition = "visibility 0s, opacity 0.5s";

					// Pequeña columna derecha:
					document.getElementById("columna-descripcion-" + nroSlideAnterior + "-der").style.display = "none";
					// document.getElementById("columna-descripcion-" + nroSlideAnterior + "-der").style.visibility = "hidden";
					// document.getElementById("columna-descripcion-" + nroSlideAnterior + "-der").style.opacity = "0";
					// document.getElementById("columna-descripcion-" + nroSlideAnterior + "-der").style.transition = "visibility 0s, opacity 0.5s";

					// -Se oculta la descripción vieja del slider siguiente-
					// Cambiando en el título el nombre del producto/proyecto:
					document.getElementById("titulo-" + nroSlideSiguiente).style.display = "none";

					// Cambiando el precio o autro del producto/proyecto:
					document.getElementById("precio-" + nroSlideSiguiente).style.display = "none";

					// Columna izquierda:
					document.getElementById("columna-descripcion-" + nroSlideSiguiente + "-izq").style.display = "none";
					// document.getElementById("columna-descripcion-" + nroSlideSiguiente + "-izq").style.visibility = "hidden";
					// document.getElementById("columna-descripcion-" + nroSlideSiguiente + "-izq").style.opacity = "0";
					// document.getElementById("columna-descripcion-" + nroSlideSiguiente + "-izq").style.transition = "visibility 0s, opacity 0.5s";

					// Pequeña columna derecha:
					document.getElementById("columna-descripcion-" + nroSlideSiguiente + "-der").style.display = "none";
					// document.getElementById("columna-descripcion-" + nroSlideSiguiente + "-der").style.visibility = "hidden";
					// document.getElementById("columna-descripcion-" + nroSlideSiguiente + "-der").style.opacity = "0";
					// document.getElementById("columna-descripcion-" + nroSlideSiguiente + "-der").style.transition = "visibility 0s, opacity 0.5s";

					// -Y se muestra la descripción actual del slider presente-
					// Cambiando en el título el nombre del producto/proyecto:
					document.getElementById("titulo-" + nroSlideActual).style.display = "inline";

					// Cambiando el precio o autro del producto/proyecto:
					document.getElementById("precio-" + nroSlideActual).style.display = "inline";

					// Columna izquierda:
					document.getElementById("columna-descripcion-" + nroSlideActual + "-izq").style.display = "block";
					// document.getElementById("columna-descripcion-" + nroSlideActual + "-der").style.visibility = "visible";
					// document.getElementById("columna-descripcion-" + nroSlideActual + "-der").style.opacity = "1";
					// document.getElementById("columna-descripcion-" + nroSlideActual + "-der").style.transition = "visibility 0s, opacity 0.5s";

					// Pequeña columna derecha:
					document.getElementById("columna-descripcion-" + nroSlideActual + "-der").style.display = "block";					
					// document.getElementById("columna-descripcion-" + nroSlideActual + "-der").style.visibility = "visible";
					// document.getElementById("columna-descripcion-" + nroSlideActual + "-der").style.opacity = "1";
					// document.getElementById("columna-descripcion-" + nroSlideActual + "-der").style.transition = "visibility 0s, opacity 0.5s";

				}
			}
		});

	});
}

function slider2() 
{
	$(document).ready(function ($)
	{

		// Opciones varias para el slider secundario:
		var options =
		{
			$AutoPlay: true,
			$AutoPlayInterval: 10000,
			$Loop: 1,
			$FillMode: 0,
			$PauseOnHover: 1,
			$DragOrientation: 1,
			$ArrowKeyNavigation: true,
			$SlideDuration: 500,
			$StartIndex: 0,

			// Flechas de navegación para slider secundario:
			$ArrowNavigatorOptions:
			{
				$Class: $JssorArrowNavigator$,
				$ChanceToShow: 1,
				$AutoCenter: 0,
				$Steps: 1
			}
		};
		var jssor_slider2 = new $JssorSlider$('slider2_container', options);
	});
}

/* ------------------------------------------ */
/* ------------------------------------------ */