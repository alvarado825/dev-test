declare module 'api' {
  export interface LoginResponse {
    token: string;
    user: {
      username: string;
      profile: UserProfile;
    };
  }

  export interface UserProfile {
    id: string;
    email: string;
    name: string;
    age: number;
  }
}