import { Component, signal, ViewChild } from '@angular/core';
import { MatExpansionPanel } from '@angular/material/expansion';
import { faCartShopping, faLocationDot, faUser} from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-navbar',
  standalone: false,

  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.scss'
})
export class NavbarComponent {
  panelOpenState = false;
  faCart = faCartShopping;
  faLocation = faLocationDot;
  faUser = faUser;
  @ViewChild('expansionPanel') expansionPanel!: MatExpansionPanel;



  showAccordion() {
    let navbarElements = document.getElementsByClassName("navbar")[0] as HTMLElement;
    let navbar = document.getElementById("navbar")!;

    const buttons = navbarElements.getElementsByTagName("button");
    const body = document.getElementsByTagName("body")[0];


    if (this.panelOpenState == false) {
      this.expansionPanel.open();


      Array.from(buttons).forEach((button) => {
        button.style.color = "black";
        button.style.backgroundColor = "lightgrey";
      });
      
      navbar.style.borderBottom = " solid 3px black"
      body.style.overflow = "hidden";
      this.panelOpenState = true;
    }
    else {
      this.expansionPanel.close();

      Array.from(buttons).forEach((button) => {
        button.style.color = "white";
        button.style.backgroundColor = "transparent";

      });
      navbar.style.borderBottom = ' solid 3px white';
      body.style.overflow = "";
      this.panelOpenState = false;
    }



  }
}
