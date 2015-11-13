using System;

using UIKit;
using Foundation;
using ObjCRuntime;
using CoreGraphics;
using System.Reflection;

namespace Xamarin.OneSignal.IOS.Binding
{
	public delegate void OneSignalResultSuccessBlock (NSDictionary result);
	public delegate void OneSignalFailureBlock (NSError error);
	public delegate void OneSignalIdsAvailableBlock(string userId,string pushToken);
	public delegate void OneSignalHandleNotificationBlock(string message,NSDictionary additionalData,bool isActive);

	[BaseType(typeof(NSObject))]
	public partial interface OneSignal
	{
		[Export("initWithLaunchOptions:")]
		IntPtr Constructor(NSDictionary launchOptions);

		[Export("initWithLaunchOptions:autoRegister:")]
		IntPtr Constructor(NSDictionary launchOptions,bool autoRegister);

		[Export("initWithLaunchOptions:handleNotification:")]
		IntPtr Constructor(NSDictionary launchOptions,OneSignalHandleNotificationBlock callback);

		[Export("initWithLaunchOptions:appId:handleNotification:")]
		IntPtr Constructor(NSDictionary launchOptions,string appId,OneSignalHandleNotificationBlock callback);

		[Export("initWithLaunchOptions:appId:handleNotification:autoRegister:")]
		IntPtr Constructor(NSDictionary launchOptions,string appId,OneSignalHandleNotificationBlock callback,bool autoRegister);

		[Export("registerForPushNotifications")]
		void RegisterForPushNotifications();

		[Static]
		[Export("setLogLevel:visualLevel:")]
		void SetLogLevel(LogLevel level,LogLevel visualLevel);

		[Static]
		[Export("setDefaultClient:")]
		void SetDefaultClient(OneSignal client);

		[Static]
		[Export("defaultClient")]
		OneSignal defaultClient();

		[Export("sendTag:value:onSuccess:onFailure:")]
		void SendTag(string key,string value,OneSignalResultSuccessBlock successBlock,OneSignalFailureBlock failureBlock);

		[Export("sendTag:value:")]
		void SendTag(string key,string value);

		[Export("sendTags:onSuccess:onFailure:")]
		void SendTags(NSDictionary keyValuePair,OneSignalResultSuccessBlock successBlock,OneSignalFailureBlock failureBlock);

		[Export("sendTags:")]
		void SendTags(NSDictionary keyValurPair);

		[Export("sendTagsWithJsonString:")]
		void SendTagsWithJsonString(string jsonString);

		[Export("getTags:onFailure:")]
		void GetTags(OneSignalResultSuccessBlock successBlock,OneSignalFailureBlock failureBlock);

		[Export("getTags:")]
		void GetTags(OneSignalResultSuccessBlock successBlock);

		[Export("deleteTag:onSuccess:onFailure:")]
		void DeleteTag(string key,OneSignalResultSuccessBlock successBlock,OneSignalFailureBlock failureBlock);

		[Export("deleteTag:")]
		void DeleteTag(string key);

		[Export("deleteTags:onSuccess:onFailure:")]
		void DeleteTags(NSArray keys,OneSignalResultSuccessBlock successBlock,OneSignalFailureBlock failureBlock);

		[Export("deleteTags:")]
		void DeleteTags(NSArray keys);

		[Export("deleteTagsWithJsonString:")]
		void DeleteTagsWithJsonString(string jsonString);

		[Export("IdsAvailable:")]
		void IdsAvailable(OneSignalIdsAvailableBlock idsAvailableBlock);

		[Export("enableInAppAlertNotification:")]
		void EnableInAppAlertNotification(bool enable);

		[Export("setSubscription:")]
		void SetSubscription(bool enable);

		[Export("postNotification:")]
		void PostNotification(NSDictionary jsonData);

		[Export("postNotification:onSuccess:onFailure:")]
		void PostNotification(NSDictionary jsonData,OneSignalResultSuccessBlock successBlock,OneSignalFailureBlock failureBlock);

		[Export("postNotificationWithJsonString:onSuccess:onFailure:")]
		void PostNotificationWithJsonString(NSString jsonData,OneSignalResultSuccessBlock successBlock,OneSignalFailureBlock failureBlock);


	}
	// The first step to creating a binding is to add your native library ("libNativeLibrary.a")
	// to the project by right-clicking (or Control-clicking) the folder containing this source
	// file and clicking "Add files..." and then simply select the native library (or libraries)
	// that you want to bind.
	//
	// When you do that, you'll notice that MonoDevelop generates a code-behind file for each
	// native library which will contain a [LinkWith] attribute. MonoDevelop auto-detects the
	// architectures that the native library supports and fills in that information for you,
	// however, it cannot auto-detect any Frameworks or other system libraries that the
	// native library may depend on, so you'll need to fill in that information yourself.
	//
	// Once you've done that, you're ready to move on to binding the API...
	//
	//
	// Here is where you'd define your API definition for the native Objective-C library.
	//
	// For example, to bind the following Objective-C class:
	//
	//     @interface Widget : NSObject {
	//     }
	//
	// The C# binding would look like this:
	//
	//     [BaseType (typeof (NSObject))]
	//     interface Widget {
	//     }
	//
	// To bind Objective-C properties, such as:
	//
	//     @property (nonatomic, readwrite, assign) CGPoint center;
	//
	// You would add a property definition in the C# interface like so:
	//
	//     [Export ("center")]
	//     CGPoint Center { get; set; }
	//
	// To bind an Objective-C method, such as:
	//
	//     -(void) doSomething:(NSObject *)object atIndex:(NSInteger)index;
	//
	// You would add a method definition to the C# interface like so:
	//
	//     [Export ("doSomething:atIndex:")]
	//     void DoSomething (NSObject object, int index);
	//
	// Objective-C "constructors" such as:
	//
	//     -(id)initWithElmo:(ElmoMuppet *)elmo;
	//
	// Can be bound as:
	//
	//     [Export ("initWithElmo:")]
	//     IntPtr Constructor (ElmoMuppet elmo);
	//
	// For more information, see http://developer.xamarin.com/guides/ios/advanced_topics/binding_objective-c/
	//
}

