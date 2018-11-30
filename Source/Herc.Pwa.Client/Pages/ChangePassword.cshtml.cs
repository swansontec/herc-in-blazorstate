namespace Herc.Pwa.Client.Pages
{
  using Herc.Pwa.Client.Components;
  public class ChangePasswordModel : BaseComponent
  {
    public const string Route = "/changePassword";
    public string NewPassword { get; set; }

  }
} 
// The change PW function from the edge docs, need to change "abcAccount" to whatever the context is called
// I think this is the right place to put it but am not sure...    
  
  //    await abcAccount.changePassword(password)
//- (void) changePassword:(NSString*) password
//              callback:(void (^)(AbcError* error)) callback;

//// Example
//[abcAccount changePassword:password callback:^(AbcError* error) {
//    if (error) {
//        // Oh no
//    } else {
//        // Yay, new password set
//    }
//}];

