import { AfterViewInit, Component } from '@angular/core';

@Component({
  selector: 'app-main-page',
  standalone: false,
  
  templateUrl: './main-page.component.html',
  styleUrl: './main-page.component.scss',

   host: {
    '(window:resize)': 'onResize()'
  }

})
export class MainPageComponent implements AfterViewInit {

    ngAfterViewInit(): void {
      this.setResizedOptions();
  }

  onResize() {
    this.setResizedOptions();
  }

    private setResizedOptions() {
      const wd = window.innerWidth;
      let video = document.getElementById("myVideo") as HTMLVideoElement;
      let image1 = document.getElementById("mainpage-cardImage1") as HTMLImageElement;
      let image2 = document.getElementById("mainpage-cardImage2") as HTMLImageElement;
      let image3 = document.getElementById("mainpage-cardImage3") as HTMLImageElement;
      if (wd <= 800) {
        video.src = './assets/img/PortraitOpeningGtShop.mp4'
        image1.src = './assets/img/Canva1Portrait.png';
        image2.src = './assets/img/Canva2Portrait.png';
        image3.src = './assets/img/Canva3Portrait.png';
      }
      else {
        video.src = './assets/img/OpeningGtShop.mp4';
        image1.src = './assets/img/Canva1.png';
        image2.src = './assets/img/Canva2.png';
        image3.src = './assets/img/Canva3.png';
      }
    }
}
