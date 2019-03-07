var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { HttpClientModule } from "@angular/common/http";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { TagInputModule } from "ngx-chips";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { MatTabsModule } from "@angular/material/tabs";
import { AngularWebStorageModule } from "angular-web-storage";
import { AppComponent } from "./app.component";
import { HomepageComponent } from "./homepage/homepage.component";
import { ImageComponent } from "./image/image.component";
import { MessagesComponent } from "./messages/messages.component";
import { NotFoundComponent } from "./not-found/not-found.component";
import { SearchComponent } from "./search/search.component";
import { ImageService } from "./services/image.service";
import { AddPhotoComponent } from "./add-photo/add-photo.component";
import { MenuComponent } from "./menu/menu.component";
import { RegisterComponent } from "./register/register.component";
import { SignInComponent } from "./user/sign-in/sign-in.component";
import { SignUpComponent } from "./user/sign-up/sign-up.component";
import { HomeComponent } from "./home/home.component";
import { ProfileComponent } from "./profile/profile.component";
import { MenuLeftComponent } from "./homepage/menu-left/menu-left.component";
import { IndexComponent } from "./user/index.component";
import { FooterComponent } from "./footer/footer.component";
import { FileDropModule } from "ngx-file-drop";
import { ConfirmationMessageComponent } from "./confirmation-message/confirmation-message.component";
import { AgreeLabelComponent } from "./agree-label/agree-label.component";
import { ImagesComponent } from "./images/images.component";
import { FollowButtonComponent } from "./follow-button/follow-button.component";
import { InformationLabelComponent } from "./information-label/information-label.component";
import { SettingsComponent } from "./settings/settings.component";
import { InputFileComponent } from "./forms/input-file/input-file.component";
import { InputTextComponent } from "./forms/input-text/input-text.component";
import { TextareaComponent } from "./forms/textarea/textarea.component";
import { SubmitButtonComponent } from "./forms/submit-button/submit-button.component";
import { ConfirmPasswordComponent } from "./forms/confirm-password/confirm-password.component";
import { InputEmailComponent } from "./forms/input-email/input-email.component";
import { AccountService } from "./services/account.service";
import { InputPasswordComponent } from "./forms/input-password/input-password.component";
import { InputOptionComponent } from "./forms/input-option/input-option.component";
import { ImageElementComponent } from "./image-element/image-element.component";
import { TagsComponent } from "./tags/tags.component";
const appRoutes = [
    {
        path: "",
        component: HomepageComponent
    },
    // {
    //   path: '',
    //   redirectTo: '/login',
    //   pathMatch: 'full'
    // },
    {
        path: "trending",
        component: HomepageComponent
    },
    {
        path: "recent",
        component: HomepageComponent
    },
    {
        path: "image/:id",
        component: ImageComponent
    },
    {
        path: "messages",
        component: MessagesComponent
    },
    {
        path: "settings",
        component: SettingsComponent
    },
    {
        path: "user/:id",
        component: ProfileComponent,
        children: [
            {
                path: "",
                component: ImagesComponent
            },
            {
                path: "recent",
                component: ImagesComponent
            }
        ]
    },
    {
        path: "upload-image",
        component: AddPhotoComponent
    },
    {
        path: "homepage",
        component: IndexComponent
    },
    {
        path: "homepage",
        component: IndexComponent
    },
    {
        path: "tags/:id",
        component: TagsComponent
    },
    // {
    //   path: "homepage",
    //   component: IndexComponent,
    //   children: [
    //     {
    //       path: "sign-in",
    //       component: SignInComponent
    //     }
    //   ]
    // },
    {
        path: "**",
        component: NotFoundComponent
    }
];
let AppModule = class AppModule {
};
AppModule = __decorate([
    NgModule({
        declarations: [
            AppComponent,
            HomepageComponent,
            ImageComponent,
            MessagesComponent,
            NotFoundComponent,
            SearchComponent,
            AddPhotoComponent,
            MenuComponent,
            RegisterComponent,
            SignInComponent,
            SignUpComponent,
            HomeComponent,
            ProfileComponent,
            MenuLeftComponent,
            IndexComponent,
            FooterComponent,
            ConfirmationMessageComponent,
            AgreeLabelComponent,
            ImagesComponent,
            FollowButtonComponent,
            InformationLabelComponent,
            SettingsComponent,
            InputFileComponent,
            InputTextComponent,
            TextareaComponent,
            SubmitButtonComponent,
            ConfirmPasswordComponent,
            InputEmailComponent,
            InputPasswordComponent,
            InputOptionComponent,
            ImageElementComponent,
            TagsComponent
            // InputEmailComponent
        ],
        imports: [
            RouterModule.forRoot(appRoutes),
            TagInputModule,
            BrowserAnimationsModule,
            FormsModule,
            ReactiveFormsModule,
            BrowserModule,
            HttpClientModule,
            MatTabsModule,
            FileDropModule,
            AngularWebStorageModule
        ],
        providers: [ImageService, AccountService],
        bootstrap: [AppComponent]
    })
], AppModule);
export { AppModule };
//# sourceMappingURL=app.module.js.map