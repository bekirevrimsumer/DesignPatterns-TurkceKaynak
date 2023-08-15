# State Design Pattern

State tasarım deseni, bir nesnenin davranışını nesnenin durum değişikliklerine göre değiştirmenin bir yolunu sağlayan bir tasarım desenidir. Bu desen, özellikle bir nesnenin farklı durumlarına sahip olduğu durumlarda kod tekrarını azaltmak, sınıflar arasındaki bağımlılığı azaltmak ve sürdürülebilir bir yapı oluşturmak için kullanılır. State tasarım deseni, bir durum makinesi olarak düşünülebilir ve nesnenin durumu değiştikçe davranışları da değişir.

### Neden Kullanılır?
State tasarım deseni şu durumlarda kullanışlıdır:

- **Nesnenin Durumları**: Bir nesnenin farklı durumlarına sahip olduğu durumda State deseni kullanılabilir. Bu durum, nesnenin davranışının farklı durumlar arasında değiştiği durumlarda ortaya çıkar.

- **Durum Geçişleri**: Nesnenin farklı durumlar arasında geçişler yapması gerekiyorsa, bu geçişleri düzenlemek için State deseni kullanılabilir. Bu sayede durum geçişlerinin yönetimi kolaylaşır.

- **Duruma Özgü Davranışlar**: Her durumun kendi davranışlarına sahip olduğu karmaşık senaryolarda State deseni kullanarak her durumun davranışını ayrı ayrı tanımlayabiliriz.

- **Yeni Durum Ekleme**: Sisteme yeni bir durum eklendiğinde mevcut kodun değiştirilmesini önler, böylece Open/Closed prensibine uyulmuş olur.

### Sorunları Nasıl Çözer?
State tasarım deseni aşağıdaki sorunları çözmeye yardımcı olur:

- **Kod Tekrarı Azaltma**: Farklı durumlar arasında paylaşılan davranışlar varsa, bu davranışları tekrar etmek yerine State deseni kullanarak bu davranışları ortak bir yerde tanımlayabiliriz.

- **Esneklik ve Genişletilebilirlik**: Yeni durumlar eklemek veya mevcut durum davranışlarını değiştirmek gerektiğinde, sadece ilgili durum sınıfını güncellemek yeterlidir. Bu, sistemin daha esnek ve genişletilebilir olmasını sağlar.

- **Bağımlılıkları Azaltma**: Durumlar arasındaki geçişler veya duruma özgü davranışlar nedeniyle oluşan sıkı bağımlılıkları azaltır. Bu, kodun daha bakımı kolay ve anlaşılır hale gelmesini sağlar.

### Örnek Uygulama
Bu örnek, dosya indirme işlemini yönetmek için State tasarım desenini kullanmaktadır. İndirme işlemi, farklı durumlar altında farklı davranışlar sergiler. Örneğin, indirme başlatıldığında dosya indirilirken, indirme duraklatıldığında indirme durdurulur. State deseni, bu farklı durumları yönetmek ve duruma özgü davranışları kolayca tanımlamak için kullanılır.

İlk olarak, IDownloadState arayüzü, indirme işleminin farklı durumlarını temsil eder ve StartDownload, PauseDownload, ResumeDownload ve CancelDownload gibi temel davranışları içerir. Ardından, her bir durumu temsil eden sınıflar olan DownloadStartedState ve DownloadPausedState oluşturulur. Bu sınıflar, ilgili duruma özgü davranışları uygular.

Ana sınıf olan DownloadManager, mevcut durumu takip eder ve StartDownload, PauseDownload, ResumeDownload ve CancelDownload gibi metotlar vasıtasıyla indirme işleminin durumuna göre davranışları yönetir. Başlangıçta DownloadPausedState durumunda başlar, bu nedenle indirme işlemi duraklatılmıştır.

Bu tasarım deseni, yeni durumlar eklemek veya mevcut davranışları değiştirmek gerektiğinde sadece ilgili durum sınıflarını güncellemenin yeterli olduğu genişletilebilir bir yapı sunar. Ayrıca, indirme işleminin farklı durumları arasındaki geçişlerin düzenlenmesini ve karmaşık bir durum makinesinin yönetimini sağlar.

Bu örnek, State tasarım deseninin bir işlem veya nesnenin farklı durumlarını yönetmek için nasıl kullanılabileceğini göstermektedir.