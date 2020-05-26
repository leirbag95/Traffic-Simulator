<p align="right">
  <a href="http://img.shields.io/badge/license-MIT-blue.svg)](https://github.com/leirbag95/Traffic-Simulator/blob/master/LICENSE">
    <img src="http://img.shields.io/badge/license-MIT-blue.svg" alt="downloads" />
  </a>
</p>


<h1 align="center">Traffic-Simulator</h1>

<h5 align="center"> Traffic-Simulator, highly performant large-scale traffic visualization</h5>

[![docs](http://i.imgur.com/mvfvgf0.jpg)](https://github.com/leirbag95/Traffic-Simulator/)

#### Before starting 

Consult [specification](https://github.com/leirbag95/Traffic-Simulator/files/2982107/Rapport_PTS_IBO_104_gabriel_elfassi.pdf)
 in pdf format for more information.

<h1 align="center">Introduction</h1>
This project is a Traffic-Simulator developped in case of studies project.

We developed it with *Unity3D*  in *C#*.

This simulator is based on New York City traffic, in fact there are pedestrian, differents kind of cars like truck or city-dweller car. **There is not roundabout**, cars can not cross each other and pedestrian can not cross the street.

For a better introduction you can watch this <a href="https://youtu.be/HV_8Rp9zvWE">video</a> which resume our Traffic-Simulator project.

## Download the project

You can clone or download the project by clicking on the button "Clone or Download".
Or you can get this command on terminal 
```
git clone https://github.com/leirbag95/Traffic-Simulator.git
``` 
## How to try it ?

 - Clone the project and launch it with Unity, then Build & Run the project with the OS you want.
 
 - Download the project for Mac OS through this  <a href="https://www.dropbox.com/s/oqb06ngq1tme0n0/Buildv2.app.zip?dl=0">link</a> 

## How does it work ?



Once you have started the program, you will be in front of the main menu where you will have several choices:
- Start a local traffic simulator

A traffic simulator will be randomly selected from a local database of document. In fact, you have a dozen of maps which are provided with the project.

- Upload your own city

Maps are generated from a JSON file. We made this simulator in order to upload your own map. Everything are explained in the specification.

Below you have an example of what looks like a city through a JSON file required

``` JSON
{
  "name":"Pulv City",
  "rows":17,
  "cols":10,
  "grid": [
  	["", "", "", "", "", "", "", "", "",""],
  	["", "", "TB", "BT", "", "TB", "BT", "", "",""],
  	["", "", "TB", "BT", "", "TB", "BT", "", "",""],
  	["", "RL", "CNO", "CNE", "RL", "CNO", "CNE", "RL", "RLS",""],
  	["", "LR", "CSO", "CSE", "LR", "CSO", "CSE", "LR", "LR",""],
  	["", "", "TB", "BT", "", "TB", "BT", "", "",""],
  	["", "", "TB", "BT", "", "TB", "BT", "", "",""],
  	["", "", "TB", "BT", "", "TB", "BT", "", "",""],
  	["", "", "TB", "BT", "", "TB", "BT", "", "",""],
  	["", "", "TB", "BT", "", "TB", "BT", "", "",""],
  	["", "", "TB", "BT", "", "TB", "BT", "", "",""],
  	["", "", "TB", "BT", "", "TB", "BT", "", "",""],
  	["", "RL", "CNO", "CNE", "RL", "CNO", "CNE", "RLS", "",""],
  	["", "LRS", "CSO", "CSE", "LR", "CSO", "CSE", "LR", "",""],
  	["", "", "TB", "BT", "", "TB", "BT", "", "",""],
  	["", "", "", "", "WP", "", "", "", "",""],
  	["", "", "", "", "", "", "", "", "",""]
  ]
}
```

### Modeling a road

Road are modeling by a matrix of *GameObject*.
There are several types of GameObject : 

###### GameObject representing the road

---

These kind of GameObject represent the direction of the road, in fact each *Road GameObject* has a peer of Node.

1. **TB** : TOP to the BOTTOM
2. **BT** : BOTTOM to the TOP
3. **RL** : RIGHT to the LEFT
4. **LR** : LEFT to the RIGHT
5. **CNO** : CENTER NORTH WEST
6. **CNE** : CENTER NORTH EAST
7. **CSO** : CENTER SUD WEST
8. **CSE** : CENTER SUD EAST

