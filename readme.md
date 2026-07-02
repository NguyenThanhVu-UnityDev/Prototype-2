# Prototype 2

Một bản prototype góc nhìn từ trên xuống (top-down survival) 3D được hoàn thành trong lộ trình Junior Programmer Pathway của Unity.

Dự án này vượt qua bài hướng dẫn cơ bản bằng cách giới thiệu kiến trúc hướng sự kiện (event-driven architecture) được tách biệt rõ ràng nhằm giảm thiểu sự phụ thuộc chéo giữa các đối tượng (coupling), áp dụng các quy chuẩn viết code sạch và tổ chức trạng thái hệ thống thông qua các Singleton.

## Demo Gameplay
![DemoGameplay](Screenshots/DemoGameplay.gif)

## Những Điều Tôi Đã Học Được

### [Lesson 2.1 - Play Fetch](https://learn.unity.com/pathway/junior-programmer/unit/basic-gameplay/tutorial/lesson-2-1-play-fetch?version=6.0)

**Tính năng mới**

- Nhập (import) các tài nguyên của dự án (bao gồm mô hình người chơi, các con thú khác nhau và prefab thức ăn).
- Khởi tạo và thiết lập vị trí cho controller của người chơi.
- Bắn các viên thức ăn từ vị trí của người chơi dựa trên các phím bấm đầu vào.

**Khái niệm & kỹ năng mới**

- **Thiết lập & Tổ chức dự án:** Nhập các gói tài nguyên bên ngoài và sắp xếp các thư mục prefab, material và script một cách hợp lý.
- **Quản lý Prefab:** Chỉnh sửa các bản thể của GameObject trong chế độ Prefab Edit Mode để đảm bảo các thay đổi được cập nhật đồng bộ trên toàn bộ dự án.
- **Hàm Instantiate:** Sử dụng `Instantiate()` để sinh động các prefab thức ăn khi chạy game.

### [Lesson 2.2 - Guard Dog](https://learn.unity.com/pathway/junior-programmer/unit/basic-gameplay/tutorial/2-2-prevent-screen-out-of-bounds?version=6.0)

**Tính năng mới**

- **Giới hạn biên độ chạy:** Giới hạn tọa độ di chuyển của người chơi một cách linh hoạt để ngăn họ chạy ra khỏi tầm nhìn màn hình.
- **Hệ thống dọn dẹp tài nguyên:** Tự động hủy các con thú và thức ăn bay ra ngoài màn hình để giải phóng bộ nhớ và tránh rò rỉ (leak) GameObject hoạt động.

**Khái niệm & kỹ năng mới**

- **Script di chuyển độc lập:** Viết các script di chuyển (translation) chung và có thể tái sử dụng (như chuyển động tiến lên phía trước).
- **Trình kiểm tra giới hạn biên (Out of Bounds):** Triển khai các ngưỡng vị trí tuyệt đối để dọn dẹp các đối tượng không còn sử dụng.
- **Giới hạn toán học (Clamping):** Giới hạn các giá trị vị trí trong các khoảng xác định bằng các hàm toán học C#.

### [Lesson 2.3 - Spawn Manager](https://learn.unity.com/pathway/junior-programmer/unit/basic-gameplay/tutorial/2-3-randomly-spawn-animals?version=6.0)

**Tính năng mới**

- **Bộ sinh thú tự động:** Lập trình một spawn manager chuyên dụng để tạo ngẫu nhiên các loại thú khác nhau tại các điểm ngang ngẫu nhiên ở phía trên màn hình.

**Khái niệm & kỹ năng mới**

- **Mảng & Chỉ mục (Arrays & Indexing):** Lưu trữ nhiều prefab động vật bên trong các bộ sưu tập mảng.
- **Hàm sinh ngẫu nhiên:** Tính toán động các tọa độ và chỉ số mảng bằng cách sử dụng các hàm tạo số ngẫu nhiên.
- **Lặp lại theo thời gian:** Kích hoạt các lượt tạo thú lặp lại theo chu kỳ định sẵn bằng cách sử dụng các phương thức như `InvokeRepeating`.

### [Lesson 2.4 - Collision Decisions](https://learn.unity.com/pathway/junior-programmer/unit/basic-gameplay/tutorial/2-4-collision-decisions?version=6.0)

**Tính năng mới**

- **Tương tác vật lý:** Thêm các thành phần Rigidbody và Box Collider vào các prefab thức ăn và động vật.
- **Giải quyết va chạm:** Động vật được cho ăn và biến mất khi va chạm với thức ăn thay vì bay xuyên qua nhau.

**Khái niệm & kỹ năng mới**

- **Va chạm kích hoạt (Trigger Collisions):** Sử dụng các hàm ghi đè `OnTriggerEnter` để phát hiện va chạm vật lý mà không tạo ra các phản ứng dội ngược cứng nhắc.
- **Hủy đối tượng hợp lý:** Hiểu rõ vòng đời của các đối tượng đồ họa bên trong vòng lặp vật lý.

## Các Tính Năng Mở Rộng & Cải Tiến (Extras)

- **Hệ thống hướng sự kiện tách biệt (Decoupled Event System):** Loại bỏ sự liên kết chặt chẽ (coupling) giữa các class bằng các sự kiện tĩnh (`UnityEvent` và `Action`). Các thành phần không trực tiếp gọi hàm của nhau mà giao tiếp thông qua các class trợ giúp trung gian:
  - **`UIEvents`**: Xử lý các sự kiện liên quan đến giao diện (ví dụ: thay đổi điểm số, mạng sống của người chơi).
  - **`GameEvents`**: Xử lý các sự kiện cốt lõi liên quan đến gameplay (ví dụ: cho ăn thành công, va chạm trừ máu).
- **GameManager theo dạng Singleton:** Thiết lập trình điều khiển cốt lõi (như `GameManager`) dưới dạng Singleton để cung cấp một điểm truy cập toàn cục duy nhất, giúp các script khác dễ dàng gọi tới mà không cần liên kết trực tiếp trong Scene.
- **Dọn dẹp code sạch theo quy chuẩn C#:** Sửa đổi các cấu trúc script mặc định từ bài học của Unity bằng cách loại bỏ các đoạn code dư thừa, tăng cường tính đóng gói, sử dụng đúng phạm vi biến và chia nhỏ logic thành các class đơn nhiệm (Single-Responsibility).
