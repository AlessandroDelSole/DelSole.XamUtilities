# DelSole.XamUtilities
A collection of controls, behaviors, and converters for Xamarin.Forms. 

[![](https://img.shields.io/badge/nuget-v1.0.0-blue.svg)](https://www.nuget.org/packages/DelSole.XamUtilities/1.0.0)

## Requirements

DelSole.XamUtilities requires at least Xamarin.Forms v. 2.3.0.49 and does not support Windows Phone 8.1 and Windows 8.1. The reason is that, behind the scenes, it requires the System.ComponentModel.Annotation library that is not supported on these platforms.

Following is a list of goodies you will find in the library:

## Controls

**NullableDatePicker** is a custom date picker that allows binding objects of type DateTime? You bind to NullableDate and you can format the date using DateFormat as you would do with the Format property of the built-in DatePicker control

**EnumBindablePicker** is a custom picker that supports binding Enum objects and support data annotations with the Display attribute and the description properties


## Converters

**ByteToImageConverter** can be used to bind a byte array to the Source property of an Image control. This is useful if your image comes from an in-memory stream or from a database

**EnumToStringConverter** can be used opposite to EnumBindablePicker and converts an Enum value into the appropriate string representation for binding

## Behaviors

**FieldEmptyValidatorBehavior** can be used to validate Entry controls and to show a red placeholder until the user types into the control.

**FieldLengthValidatorBehavior** can be used to validate Entry controls and to cut the length of a string, given the MaxLength property.

## Styles

The **SharedResources.xaml** resource dictionary contains a couple of styles that can be used with behaviors for validation. They are not intended to be used outside of that scope.

## Sample app

The solution contains a companion sample app that demonstrates how to use controls, converters, and behaviors. Check it out, it's really easy to use!

## Downloads

DelSole.XamUtilities is available as a [NuGet package](https://www.nuget.org/packages/DelSole.XamUtilities/1.0.0) that you can download from Visual Studio. 
