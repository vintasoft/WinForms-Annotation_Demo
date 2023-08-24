# VintaSoft WinForms Annotation Demo

The project uses <a href="https://www.vintasoft.com/vsimaging-dotnet-index.html">VintaSoft Imaging .NET SDK</a> and demonstrates how to annotate images and documents in WinForms:
* Interactively add 20+ predefined annotation types onto JPEG, PNG, TIFF image or PDF page.
* Use source codes of custom annotations as an example of custom annotation development.
* Manipulate annotations: copy/paste, cut, delete, burn on image, resize, rotate.
* Load/save annotations from/to XML, JPEG, PNG, TIFF or PDF file in VintasoftBinary, XMP or WANG format.
* Display, save and print images with annotations.
* Navigate images: first, previous, next, last.
* Change settings of image preview.
* Use visual tools for interactive image processing: selection, magnifier, crop, drag-n-drop, zoom, pan, scroll.


## Screenshot
<img src="vintasoft-annotation-demo.png" alt="VintaSoft Annotation Demo">


## Usage
1. Get the 30 day free evaluation license for <a href="https://www.vintasoft.com/vsimaging-dotnet-index.html" target="_blank">VintaSoft Imaging .NET SDK</a> as described here: <a href="https://www.vintasoft.com/docs/vsimaging-dotnet/Licensing-Evaluation.html" target="_blank">https://www.vintasoft.com/docs/vsimaging-dotnet/Licensing-Evaluation.html</a>

2. Update the evaluation license in "CSharp\MainForm.cs" file:
   ```
   Vintasoft.Imaging.ImagingGlobalSettings.Register("REG_USER", "REG_EMAIL", "EXPIRATION_DATE", "REG_CODE");
   ```

3. Build the project ("AnnotationDemo.Net7.csproj" file) in Visual Studio or using .NET CLI:
   ```
   dotnet build AnnotationDemo.Net7.csproj
   ```

4. Run compiled application and try to annotate images and documents.


## Documentation
VintaSoft Imaging .NET SDK on-line User Guide and API Reference for .NET developer is available here: https://www.vintasoft.com/docs/vsimaging-dotnet/


## Support
Please visit our <a href="https://myaccount.vintasoft.com/">online support center</a> if you have any question or problem.
