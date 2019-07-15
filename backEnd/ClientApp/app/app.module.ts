import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { HttpClientModule } from "@angular/common/http";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { TagInputModule } from "ngx-chips";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { MatTabsModule } from "@angular/material/tabs";
import { AngularWebStorageModule } from "angular-web-storage";
import { RecaptchaModule } from "ng-recaptcha";
import { RecaptchaFormsModule } from "ng-recaptcha/forms";

import { AppComponent } from "./app.component";
import { HomepageComponent } from "./pages/homepage/homepage.component";
import { ImageComponent } from "./pages/image/image.component";
import { NotFoundComponent } from "./pages/not-found/not-found.component";
import { SearchComponent } from "./single-components/search/search.component";
import { ImageService } from "./services/image.service";
import { AddPhotoComponent } from "./pages/add-photo/add-photo.component";
import { MenuComponent } from "./constant-elements/menu/menu.component";
import { ProfileComponent } from "./pages/profile/profile.component";
import { IndexComponent } from "./pages/index/index.component";
import { FooterComponent } from "./constant-elements/footer/footer.component";
// import { FileDropModule } from "ngx-file-drop";
import { ConfirmationMessageComponent } from "./propmts/confirmation-message/confirmation-message.component";
import { AgreeLabelComponent } from "./propmts/agree-label/agree-label.component";
import { ImagesComponent } from "./images-all/images/images.component";
import { FollowButtonComponent } from "./single-components/follow-button/follow-button.component";
import { InformationLabelComponent } from "./propmts/information-label/information-label.component";
import { SettingsComponent } from "./pages/settings/settings.component";
import { InputFileComponent } from "./forms/input-file/input-file.component";
import { InputTextComponent } from "./forms/input-text/input-text.component";
import { TextareaComponent } from "./forms/textarea/textarea.component";
import { SubmitButtonComponent } from "./forms/submit-button/submit-button.component";
import { ConfirmPasswordComponent } from "./forms/confirm-password/confirm-password.component";
import { InputEmailComponent } from "./forms/input-email/input-email.component";
import { AccountService } from "./services/account.service";
import { InputPasswordComponent } from "./forms/input-password/input-password.component";
import { InputOptionComponent } from "./forms/input-option/input-option.component";
import { ImageElementComponent } from "./images-all/image-element/image-element.component";
import { TagsComponent } from "./pages/tags/tags.component";
import { ImagesCommonComponent } from "./images-all/images-common/images-common.component";
import { InformationsComponent } from "./pages/settings/informations/informations.component";
import { CredentialsComponent } from "./pages/settings/credentials/credentials.component";
import { UserService } from "./services/user.service";
import { InputCheckboxComponent } from "./forms/input-checkbox/input-checkbox.component";
import { EditableFieldComponent } from "./single-components/editable-field/editable-field.component";
import { CommentWrapperComponent } from "./comments/comment-wrapper/comment-wrapper.component";
import { AddCommentComponent } from "./comments/add-comment/add-comment.component";
import { CommentsLogicComponent } from "./comments/comments-logic/comments-logic.component";
import { LikesComponent } from './likes/likes.component';

const appRoutes: Routes = [
  {
    path: "",
    component: HomepageComponent
  },
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
    path: "settings",
    component: SettingsComponent,
    children: [
      {
        path: "",
        component: InformationsComponent
      },
      {
        path: "credentials",
        component: CredentialsComponent
      }
    ]
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

@NgModule({
  declarations: [
    AppComponent,
    HomepageComponent,
    ImageComponent,
    NotFoundComponent,
    SearchComponent,
    AddPhotoComponent,
    MenuComponent,
    ProfileComponent,
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
    TagsComponent,
    ImagesCommonComponent,
    InformationsComponent,
    CredentialsComponent,
    InputCheckboxComponent,
    EditableFieldComponent,
    CommentWrapperComponent,
    AddCommentComponent,
    CommentsLogicComponent,
    LikesComponent
    // InputEmailComponent
  ],
  imports: [
    RouterModule.forRoot(appRoutes),
    ReactiveFormsModule,
    BrowserModule,
    HttpClientModule,
    MatTabsModule,
    // FileDropModule,
    AngularWebStorageModule,
    TagInputModule,
    BrowserAnimationsModule,
    FormsModule,
    RecaptchaModule,
    RecaptchaFormsModule
  ],
  providers: [ImageService, AccountService, UserService],
  bootstrap: [AppComponent]
})
export class AppModule {}
