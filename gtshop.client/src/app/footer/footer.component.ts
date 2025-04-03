import { Component } from '@angular/core';
import { faFacebook, faInstagram, faXTwitter, faWhatsapp, faTiktok, faYoutube, faLinkedin } from '@fortawesome/free-brands-svg-icons';

@Component({
  selector: 'app-footer',
  standalone: false,
  
  templateUrl: './footer.component.html',
  styleUrl: './footer.component.scss'
})
export class FooterComponent {

  array = Array(7);
  faFace = faFacebook;
  faInsta = faInstagram;
  faX = faXTwitter;
  faWhats = faWhatsapp;
  faTik = faTiktok;
  faYou = faYoutube;
  faLink = faLinkedin;

  constructor() {
    this.array = [this.faFace, this.faInsta, this.faX, this.faWhats, this.faTik, this.faYou, this.faLink];
  }

}
