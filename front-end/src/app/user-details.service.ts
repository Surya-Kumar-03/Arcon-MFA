import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class UserDetailsService {
  async getUserDetails(): Promise<any> {
    const userAgent = window.navigator.userAgent;
    const os = this.getOperatingSystem(userAgent);
    const browser = this.getBrowser(userAgent);
    const version = this.getBrowserVersion(userAgent);

    let latitude, longitude;
    try {
      const position = await this.getPosition();
      latitude = position.lat;
      longitude = position.lng;
    } catch (error) {
      console.error('Error getting user location:', error);
    }

    return {
      os,
      browser,
      version,
      latitude,
      longitude,
    };
  }

  getPosition(): Promise<any> {
    return new Promise((resolve, reject) => {
      navigator.geolocation.getCurrentPosition(
        (resp) => {
          resolve({ lng: resp.coords.longitude, lat: resp.coords.latitude });
        },
        (err) => {
          reject(err);
        }
      );
    });
  }

  private getOperatingSystem(userAgent: string): string {
    if (/Windows/i.test(userAgent)) {
      return 'Windows';
    } else if (/Linux/i.test(userAgent)) {
      return 'Linux';
    } else if (/Mac/i.test(userAgent)) {
      return 'Mac';
    } else if (/Android/i.test(userAgent)) {
      return 'Android';
    } else if (/iOS/i.test(userAgent)) {
      return 'iOS';
    } else {
      return 'Unknown';
    }
  }

  private getBrowser(userAgent: string): string {
    if (/Chrome/i.test(userAgent)) {
      return 'Chrome';
    } else if (/Firefox/i.test(userAgent)) {
      return 'Firefox';
    } else if (/Safari/i.test(userAgent)) {
      return 'Safari';
    } else if (/Edge/i.test(userAgent)) {
      return 'Edge';
    } else if (/Opera/i.test(userAgent)) {
      return 'Opera';
    } else {
      return 'Unknown';
    }
  }

  private getBrowserVersion(userAgent: string): string {
    const matches = userAgent.match(/\d+\.\d+\.\d+/);
    return matches ? matches[0] : 'Unknown';
  }
}
