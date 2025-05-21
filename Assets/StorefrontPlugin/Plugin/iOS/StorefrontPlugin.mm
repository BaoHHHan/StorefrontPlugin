#import <Foundation/Foundation.h>
#import <StoreKit/StoreKit.h>

extern "C" {
const char* _GetStorefrontCountryCode() {
    if (@available(iOS 16.0, *)) {
        SKStorefront *sf = [SKPaymentQueue defaultQueue].storefront;
        if (sf.countryCode) {
            return strdup([sf.countryCode UTF8String]);
        }
    }
    return strdup("");
}
}
